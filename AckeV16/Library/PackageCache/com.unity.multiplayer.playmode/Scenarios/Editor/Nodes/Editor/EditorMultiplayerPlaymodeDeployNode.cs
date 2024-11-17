using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unity.Multiplayer.PlayMode.Scenarios.Editor.GraphsFoundation;
using Unity.Multiplayer.Playmode.Workflow.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Multiplayer.PlayMode.Common.Editor;
using Unity.Multiplayer.Playmode.VirtualProjects.Editor;

namespace Unity.Multiplayer.PlayMode.Scenarios.Editor.Nodes.Editor
{
    class EditorMultiplayerPlaymodeDeployNode : Node
    {
        bool m_HasConnected;
#if UNITY_USE_MULTIPLAYER_ROLES

        [SerializeReference] public NodeInput<MultiplayerRoleFlags> MultiplayerRole;
#endif
        [SerializeReference] public NodeInput<int> PlayerInstanceIndex;
        [SerializeReference] public NodeInput<SceneAsset> InitialScene;
        [SerializeReference] public NodeInput<string> PlayerTags;
        [SerializeReference] public NodeOutput<PlayerIdentifier> PlayerIdentifier; // Nodes needs to be public fields since they are serialized
        [SerializeReference] public NodeOutput<TypeDependentPlayerInfo> TypeDependentPlayerInfo; // Nodes needs to be public fields since they are serialized

        [SerializeField] private EditorBuildSettingsScene[] m_OriginalScenes;
        [SerializeField] private string m_SceneName;
        [SerializeField] private string m_SentMessage;

        public EditorMultiplayerPlaymodeDeployNode(string name) : base(name)
        {
            PlayerInstanceIndex = new(this);
            InitialScene = new(this);
#if UNITY_USE_MULTIPLAYER_ROLES
            MultiplayerRole = new(this);
#endif
            PlayerTags = new(this);

            PlayerIdentifier = new(this);
            TypeDependentPlayerInfo = new(this);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var playerInstanceIndex = GetInput(PlayerInstanceIndex);
            var player = MultiplayerPlaymode.Players[playerInstanceIndex];
            DebugUtils.Trace($"Deploy started for '{player.Name}'");
            var hasActivated = player.Activate(out _);
            DebugUtils.Trace(hasActivated
                ? $"Successfully activated '{player.Name}'"
                : $"Failed to activate '{player.Name}'");

            if (player.Type == PlayerType.Main)
            {
                var initialScene = GetInput(InitialScene);
                var currentScene = SceneManager.GetActiveScene();
                if (initialScene != null && AssetDatabase.GetAssetPath(initialScene) != currentScene.path)
                {
                    EditorApplication.playModeStateChanged -= LoadInitialScene;
                    EditorApplication.playModeStateChanged += LoadInitialScene;
                }
            }

            if (hasActivated)
            {
                // Set Tags
                var tags = GetInput(PlayerTags).Split('|');
                foreach (var tag in tags)
                {
                    if (string.IsNullOrWhiteSpace(tag)) continue;
                    if (player.Tags.Contains(tag)) continue;
                    if (player.AddTag(tag, out var tagError)) continue;

                    Debug.Log($"Could not add tag '{tag}'. Reason[{tagError}]");
                }

#if UNITY_USE_MULTIPLAYER_ROLES
                // Set role
                player.Role = GetInput(MultiplayerRole);
#endif

                // Activating at first could take a while
                // 1. Could be symbolic linking the MPPM folder
                // 2. Could be launching the process
                while (player.PlayerState != PlayerState.Launched)
                {
                    await Task.Delay(3000);

                    if (player.PlayerState != PlayerState.Launched)
                    {
                        DebugUtils.Trace($"'{player.Name}' is not in the ready state");
                    }
                    else
                    {
                        if (!m_HasConnected)
                        {
                            m_HasConnected = true;
                            DebugUtils.Trace($"'{player.Name}' is ready!");
                        }
                    }
                }
            }

            DebugUtils.Trace($"Deploy finished for '{player.Name}'");

            SetOutput(PlayerIdentifier, player.PlayerIdentifier);
            SetOutput(TypeDependentPlayerInfo, player.TypeDependentPlayerInfo);
        }

        protected override Task ExecuteResumeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        protected override async Task MonitorAsync(CancellationToken cancellationToken)
        {
            var startTime = DateTime.UtcNow;
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(100);

                if ((DateTime.UtcNow - startTime).TotalSeconds > 20)
                {
                    if (!string.IsNullOrWhiteSpace(m_SentMessage) && EditorApplication.isPlaying)
                    {
                        startTime = DateTime.UtcNow;
                        DebugUtils.Trace($"Sending to clone runtime scene {m_SentMessage}");
                        var mainEditorContext = Playmode.VirtualProjects.Editor.EditorContexts.MainEditorContext;
                        var m = new RuntimeSceneSwitchMessage(m_SentMessage);
                        mainEditorContext.MessagingService.Broadcast(m, () => { m_SentMessage = null; }, Debug.LogWarning);
                    }
                }

                if (!string.IsNullOrWhiteSpace(m_SceneName) && EditorApplication.isPlaying)
                {
                    DebugUtils.Trace($"Loaded into '{m_SceneName}'");
                    EditorApplication.playModeStateChanged -= LoadInitialScene;
                    SceneManager.LoadScene(m_SceneName, LoadSceneMode.Single);

                    EditorBuildSettings.scenes = m_OriginalScenes;
                    m_OriginalScenes = null;

                    m_SentMessage = m_SceneName;
                    m_SceneName = null;
                }
            }
        }

        private void LoadInitialScene(PlayModeStateChange state)
        {
            var initialScene = GetInput(InitialScene);

            if (state == PlayModeStateChange.ExitingEditMode)
            {
                DebugUtils.Trace($"Switching to the initial scene of '{initialScene.name}'");
                // Make sure the scene is part of the build settings.
                m_OriginalScenes = EditorBuildSettings.scenes;
                var scenePath = AssetDatabase.GetAssetPath(initialScene);
                var isSceneInSettings = false;
                foreach (var scene in m_OriginalScenes)
                {
                    if (scene.path == scenePath)
                    {
                        isSceneInSettings = true;
                        break;
                    }
                }

                if (!isSceneInSettings)
                {
                    var newScenes = m_OriginalScenes.ToList();
                    newScenes.Add(new EditorBuildSettingsScene(scenePath, true));
                    EditorBuildSettings.scenes = newScenes.ToArray();
                }

                m_SceneName = initialScene.name;
            }
            else if (state == PlayModeStateChange.EnteredPlayMode)
            {
                if (!string.IsNullOrWhiteSpace(m_SceneName))
                {
                    DebugUtils.Trace($"Loaded into '{m_SceneName}'");
                    EditorApplication.playModeStateChanged -= LoadInitialScene;
                    SceneManager.LoadScene(m_SceneName, LoadSceneMode.Single);
                    EditorBuildSettings.scenes = m_OriginalScenes;
                    m_OriginalScenes = null;

                    m_SentMessage = m_SceneName;
                    m_SceneName = null;
                }
            }
        }
    }
}

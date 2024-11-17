using System.Threading;
using System.Threading.Tasks;
using UnityEditor;

namespace Unity.Multiplayer.PlayMode.Configurations.Editor
{
    internal class DefaultPlayModeConfig : PlayModeConfig
    {
        public override bool SupportsPauseAndStep => true;
        public override Task ExecuteStartAsync(CancellationToken cancellationToken)
        {
            EditorApplication.EnterPlaymode();
            return Task.CompletedTask;
        }

        public override void ExecuteStop()
        {
            EditorApplication.ExitPlaymode();
        }

        void OnEnable()
        {
            name = "Default";
            Description = "Default play mode";
        }

        // override public VisualElement CreateTopbarUI()
        // {
        //     return new Label("Default");
        // }
    }
}

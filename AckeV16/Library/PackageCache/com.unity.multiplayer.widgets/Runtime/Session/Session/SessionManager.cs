using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Multiplayer;
using UnityEngine;

namespace Unity.Multiplayer.Widgets
{
    /// <summary>
    /// The SessionManager handles the lifecycle of a Session.
    ///
    /// When the application is quit the SessionManager will leave the active session.
    /// </summary>
    [DefaultExecutionOrder(-100)]
    internal class SessionManager : LazySingleton<SessionManager>
    {
        bool m_Initialized;

        QuerySessionsResults m_SessionQueryResults;

        WidgetEventDispatcher m_WidgetEventDispatcher;

        ISession m_ActiveSession;

        internal ISession ActiveSession
        {
            get => m_ActiveSession;
            private set
            {
                if (value != null)
                {
                    m_ActiveSession = value;
                    RegisterSessionEvents();
                    Debug.Log($"Joined Session {m_ActiveSession.Id}");
                    m_WidgetEventDispatcher.OnSessionJoined(m_ActiveSession, EnterSessionData.WidgetConfiguration);
                }
                else if (m_ActiveSession != null)
                {
                    m_ActiveSession = null;
                    m_WidgetEventDispatcher.OnSessionLeft();
                }
            }
        }

        EnterSessionData EnterSessionData { get; set; }

        async void Awake()
        {
            if (!m_Initialized)
            {
                WidgetEventDispatcher.Instance.OnServicesInitializedEvent.AddListener(OnServicesInitialized);
                await WidgetServiceInitialization.SetupAsync();
            }
        }

        void Start()
        {
            m_WidgetEventDispatcher = WidgetEventDispatcher.Instance;
        }

        void OnServicesInitialized()
        {
            m_Initialized = true;
        }
        
        internal async Task EnterSession(EnterSessionData enterSessionData)
        {
            try
            {
                if (!m_Initialized)
                    throw new InvalidOperationException($"Services are not initialized. If you manually initialize Services please call {nameof(WidgetServiceInitialization.ServicesInitialized)} afterwards.");

                EnterSessionData = enterSessionData;

                if (m_ActiveSession != null)
                {
                    await LeaveSession();
                }

                var playerProperties = await GetPlayerProperties();

                Debug.Log("Joining Session...");
                m_WidgetEventDispatcher.OnSessionJoining();

                var joinSessionOptions = new JoinSessionOptions
                {
                    PlayerProperties = playerProperties
                };

                var sessionOptions = new SessionOptions
                {
                    MaxPlayers = enterSessionData.WidgetConfiguration.MaxPlayers,
                    IsLocked = false,
                    IsPrivate = false,
                    PlayerProperties = playerProperties,
                    Name = enterSessionData.SessionAction == SessionAction.Create ? enterSessionData.SessionName : Guid.NewGuid().ToString()
                };
                
                SetConnection(ref sessionOptions, enterSessionData.WidgetConfiguration);

                if (enterSessionData.WidgetConfiguration.ConnectionType != ConnectionType.None && enterSessionData.WidgetConfiguration.NetworkHandler != null)
                {
                    sessionOptions.WithNetworkHandler(enterSessionData.WidgetConfiguration.NetworkHandler);
                    joinSessionOptions.WithNetworkHandler(enterSessionData.WidgetConfiguration.NetworkHandler);
                }

                switch (enterSessionData.SessionAction)
                {
                    case SessionAction.Create:
                        ActiveSession = await MultiplayerService.Instance.CreateSessionAsync(sessionOptions);
                        break;
                    case SessionAction.StartMatchmaking:
                        ActiveSession = await MultiplayerService.Instance.MatchmakeSessionAsync(enterSessionData.AdditionalOptions.MatchmakerOptions, sessionOptions);
                        break;
                    case SessionAction.QuickJoin:
                        var quickJoinOptions = new QuickJoinOptions
                        {
                            CreateSession = enterSessionData.AdditionalOptions.AutoCreateSession
                        };
                        ActiveSession = await MultiplayerService.Instance.MatchmakeSessionAsync(quickJoinOptions, sessionOptions);
                        break;
                    case SessionAction.JoinByCode:
                        ActiveSession = await MultiplayerService.Instance.JoinSessionByCodeAsync(enterSessionData.JoinCode, joinSessionOptions);
                        break;
                    case SessionAction.JoinById:
                        ActiveSession = await MultiplayerService.Instance.JoinSessionByIdAsync(enterSessionData.Id, joinSessionOptions);
                        break;
                    case SessionAction.Invalid:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (SessionException sessionException)
            {
                HandleSessionException(sessionException);
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    if (ex is SessionException sessionException)
                    {
                        HandleSessionException(sessionException);
                        return true;
                    }

                    return false;
                });
            }
        }

        void HandleSessionException(SessionException sessionException)
        {
            Debug.LogException(sessionException);
            m_WidgetEventDispatcher.OnSessionFailedToJoin(sessionException);
            ActiveSession = null;
        }

        async Task<Dictionary<string, PlayerProperty>> GetPlayerProperties()
        {
            var playerName = await AuthenticationService.Instance.GetPlayerNameAsync();
            var playerNameProperty = new PlayerProperty(playerName, VisibilityPropertyOptions.Member);
            var playerProperties = new Dictionary<string, PlayerProperty> { { SessionConstants.playerNamePropertyKey, playerNameProperty } };
            return playerProperties;
        }

        static void SetConnection(ref SessionOptions options, WidgetConfiguration config)
        {
            switch (config.ConnectionType)
            {
                case ConnectionType.None:
                    break;
                case ConnectionType.Direct:
                    options.WithDirectNetwork(config.ListenIpAddress, 
                        config.ConnectionMode == ConnectionMode.Listen ? config.ListenIpAddress : config.PublishIpAddress, 
                        config.Port);
                    break;
#if NGO_2_AVAILABLE                  
                case ConnectionType.DistributedAuthority:
                    options.WithDistributedAuthorityNetwork();
                    break;
#endif
                case ConnectionType.Relay:
                default:
                    options.WithRelayNetwork();
                    break;
            }
        }
        
        internal async Task<IList<ISessionInfo>> QuerySessions()
        {
            var sessionQueryOptions = new QuerySessionsOptions();
            m_SessionQueryResults = await MultiplayerService.Instance.QuerySessionsAsync(sessionQueryOptions);
            return m_SessionQueryResults.Sessions;
        }
        
        internal async Task LeaveSession()
        {
            if (ActiveSession != null)
            {
                UnregisterPlayerEvents();
                
                try
                {
                    await ActiveSession.LeaveAsync();    
                }
                catch
                {
                    // Ignored as we are exiting the game
                }
                finally
                {
                    ActiveSession = null;
                }
            }
        }

        internal async void KickPlayer(string playerId)
        {
            if (!ActiveSession.IsHost)
                return;

            await ActiveSession.AsHost().RemovePlayerAsync(playerId);
        }
        
        void RegisterSessionEvents()
        {
            ActiveSession.Changed += m_WidgetEventDispatcher.OnSessionChanged;
            ActiveSession.StateChanged += m_WidgetEventDispatcher.OnSessionStateChanged;
            ActiveSession.PlayerJoined += m_WidgetEventDispatcher.OnPlayerJoinedSession;
            ActiveSession.PlayerLeft += m_WidgetEventDispatcher.OnPlayerLeftSession;
            ActiveSession.SessionPropertiesChanged += m_WidgetEventDispatcher.OnSessionPropertiesChanged;
            ActiveSession.PlayerPropertiesChanged += m_WidgetEventDispatcher.OnPlayerPropertiesChanged;
            ActiveSession.RemovedFromSession += m_WidgetEventDispatcher.OnRemovedFromSession;
            ActiveSession.Deleted += m_WidgetEventDispatcher.OnSessionDeleted;
            
            ActiveSession.RemovedFromSession += OnRemovedFromSession;
        }
        
        void UnregisterPlayerEvents()
        {
            ActiveSession.Changed -= m_WidgetEventDispatcher.OnSessionChanged;
            ActiveSession.StateChanged -= m_WidgetEventDispatcher.OnSessionStateChanged;
            ActiveSession.PlayerJoined -= m_WidgetEventDispatcher.OnPlayerJoinedSession;
            ActiveSession.PlayerLeft -= m_WidgetEventDispatcher.OnPlayerLeftSession;
            ActiveSession.SessionPropertiesChanged -= m_WidgetEventDispatcher.OnSessionPropertiesChanged;
            ActiveSession.PlayerPropertiesChanged -= m_WidgetEventDispatcher.OnPlayerPropertiesChanged;
            ActiveSession.RemovedFromSession -= m_WidgetEventDispatcher.OnRemovedFromSession;
            ActiveSession.Deleted -= m_WidgetEventDispatcher.OnSessionDeleted;
            
            ActiveSession.RemovedFromSession -= OnRemovedFromSession;
        }

        async void OnRemovedFromSession()
        {
            await LeaveSession();
        }
    }
}
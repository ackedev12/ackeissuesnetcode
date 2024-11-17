using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace Unity.Multiplayer.Widgets
{
    /// <summary>
    /// Initialization class for all services.
    ///
    /// By default, UnityServices are initialized and an anonymous sign in is done. Vivox is also initialized when installed.
    ///
    /// To handle initialization manually enable the <see cref="MultiplayerWidgetsSettings.UseCustomServiceInitialization"/> setting in
    /// the project settings.
    ///
    /// Call <see cref="WidgetServiceInitialization.ServicesInitialized"/> when initialization is done.
    /// </summary>
    public static class WidgetServiceInitialization
    {
        // Reset IsInitialized to support domain reload disabled. 
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            IsInitialized = false;
        }
        
        /// <summary>
        /// True if UnityServices, AuthenticationService and VivoxService (if installed) are initialized.
        /// </summary>
        public static bool IsInitialized { get; private set; }

        /// <summary>
        /// UnityServices, AuthenticationService and VivoxService (if installed) are initialized.
        ///
        /// Register an event to SessionEventDispatcher.Instance.OnInitializationDone to be notified when the initialization is done.
        /// </summary>
        internal static async Task SetupAsync()
        {
            var widgetSettings = Resources.Load<MultiplayerWidgetsSettings>(nameof(MultiplayerWidgetsSettings));

            if (widgetSettings != null && widgetSettings.UseCustomServiceInitialization)
                return;
                
            if (UnityServices.State != ServicesInitializationState.Initialized)
            {
                await UnityServices.InitializeAsync();
                Debug.Log("Initialized Unity Services");
            }

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                var name = await AuthenticationService.Instance.GetPlayerNameAsync();
                Debug.Log($"Signed in anonymously. Name: {name}. ID: {AuthenticationService.Instance.PlayerId}");
            }

            var chatService = ChatServiceFactory.GetChatService();

            if (chatService != null)
                await chatService.InitializeAsync();

            ServicesInitialized();
        }

        /// <summary>
        /// Called after all services are initialized.
        /// </summary>
        public static void ServicesInitialized()
        {
            IsInitialized = true;
            WidgetEventDispatcher.Instance.OnServicesInitialized();
        }
    }
}

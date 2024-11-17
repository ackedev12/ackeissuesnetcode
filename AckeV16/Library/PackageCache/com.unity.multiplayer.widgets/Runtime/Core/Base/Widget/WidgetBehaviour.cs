using System;
using UnityEngine;

namespace Unity.Multiplayer.Widgets
{
    /// <summary>
    /// Base Class for Widgets.
    ///
    /// Registers itself to the <see cref="WidgetEventDispatcher"/> to call events.
    /// </summary>
    internal abstract class WidgetBehaviour : MonoBehaviour, IWidget
    {
        bool m_IsQuitting;
        
        /// <summary>
        /// If the Widget is initialized.
        /// </summary>
        public bool IsInitialized { get; set; }
        
        /// <summary>
        /// Access the concrete <see cref="IChatService"/>.
        /// </summary>
        protected IChatService ChatService => ChatServiceFactory.GetChatService();

        /// <summary>
        /// Register the Widget to the <see cref="WidgetEventDispatcher"/>.
        /// </summary>
        protected virtual void OnEnable()
        {
            WidgetEventDispatcher.Instance.RegisterWidget(this);
        }

        /// <summary>
        /// Unregister the Widget to the <see cref="WidgetEventDispatcher"/>.
        /// </summary>
        protected virtual void OnDisable()
        {
            // Only unregister when the application is not quitting because Execution order of OnDisable and OnDestroy is not guaranteed.
            // Therefor the Instance might be null when OnDisable is called.
            if(!m_IsQuitting)
                WidgetEventDispatcher.Instance.UnregisterWidget(this);
        }

        /// <summary>
        /// Called when the services are initialized.
        /// </summary>
        public virtual void OnServicesInitialized()
        {
            
        }
        
        void OnApplicationQuit()
        {
            m_IsQuitting = true;
        }
    }
}

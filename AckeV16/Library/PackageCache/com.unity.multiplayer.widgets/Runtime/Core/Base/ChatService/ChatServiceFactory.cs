using UnityEngine;

namespace Unity.Multiplayer.Widgets
{
    internal static class ChatServiceFactory
    {
        static bool s_Initialized;
        
        static IChatService s_ChatService;
        
        internal static IChatService GetChatService()
        {
            if (s_Initialized) return s_ChatService;
            
#if VIVOX_AVAILABLE
            s_ChatService = new VivoxChatService();
#else
            s_ChatService = null;
#endif

            s_Initialized = true;
            return s_ChatService;
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            s_Initialized = false;
            s_ChatService = null;
        }
    }
}

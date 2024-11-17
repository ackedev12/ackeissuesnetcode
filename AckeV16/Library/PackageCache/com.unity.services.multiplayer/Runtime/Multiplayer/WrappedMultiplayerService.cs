using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Unity.Services.Multiplayer
{
    class WrappedMultiplayerService : IMultiplayerService
    {
        public event Action<ISession> SessionAdded
        {
            add => m_SessionManager.SessionAdded += value;
            remove => m_SessionManager.SessionAdded -= value;
        }

        public event Action<ISession> SessionRemoved
        {
            add => m_SessionManager.SessionRemoved += value;
            remove => m_SessionManager.SessionRemoved -= value;
        }

        IReadOnlyDictionary<string, ISession> IMultiplayerService.Sessions => m_SessionManager.Sessions;

        readonly ISessionQuerier m_SessionQuerier;
        readonly ISessionManager m_SessionManager;
        readonly IMatchmakerManager m_MatchmakerManager;
        readonly IModuleRegistry m_ModuleRegistry;

        internal WrappedMultiplayerService(
            ISessionQuerier sessionQuerier,
            ISessionManager sessionManager,
            IMatchmakerManager matchmakerManager,
            IModuleRegistry moduleRegistry)
        {
            m_SessionQuerier = sessionQuerier;
            m_SessionManager = sessionManager;
            m_MatchmakerManager = matchmakerManager;
            m_ModuleRegistry = moduleRegistry;
        }

        public Task<IHostSession> CreateSessionAsync(SessionOptions sessionOptions)
        {
            try
            {
                return m_SessionManager.CreateAsync(sessionOptions).ContinueWith(t => (IHostSession)t.Result);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<ISession> CreateOrJoinSessionAsync(string sessionId, SessionOptions sessionOptions)
        {
            try
            {
                return m_SessionManager.CreateOrJoinAsync(sessionId, sessionOptions).ContinueWith(t => (ISession)t.Result);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<ISession> JoinSessionByIdAsync(string sessionId, JoinSessionOptions sessionOptions)
        {
            try
            {
                return m_SessionManager.JoinByIdAsync(sessionId, sessionOptions).ContinueWith(t => (ISession)t.Result);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<ISession> JoinSessionByCodeAsync(string sessionCode, JoinSessionOptions sessionOptions)
        {
            try
            {
                return m_SessionManager.JoinByCodeAsync(sessionCode, sessionOptions).ContinueWith(t => (ISession)t.Result);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<ISession> ReconnectToSessionAsync(string sessionId, ReconnectSessionOptions options = default)
        {
            try
            {
                return m_SessionManager.ReconnectAsync(sessionId, options).ContinueWith(t => (ISession)t.Result);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<ISession> MatchmakeSessionAsync(QuickJoinOptions quickJoinOptions, SessionOptions sessionOptions)
        {
            try
            {
                return m_SessionManager.QuickJoinAsync(quickJoinOptions, sessionOptions).ContinueWith(t => (ISession)t.Result);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<ISession> MatchmakeSessionAsync(MatchmakerOptions matchOptions, SessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            try
            {
                return m_MatchmakerManager.StartAsync(matchOptions, sessionOptions, cancellationToken);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<QuerySessionsResults> QuerySessionsAsync(QuerySessionsOptions queryOptions)
        {
            try
            {
                return m_SessionQuerier.QueryAsync(queryOptions);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public Task<List<string>> GetJoinedSessionIdsAsync()
        {
            try
            {
                return m_SessionManager.GetJoinedSessionIdsAsync().ContinueWith(t => (List<string>)t.Result);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }

        public void RegisterModuleProvider<T>(T moduleProvider) where T : IModuleProvider
        {
            try
            {
                m_ModuleRegistry.RegisterModuleProvider(moduleProvider);
            }
            catch (Exception e) when (e is not SessionException)
            {
                throw new SessionException(e.Message, SessionError.Unknown);
            }
        }
    }
}

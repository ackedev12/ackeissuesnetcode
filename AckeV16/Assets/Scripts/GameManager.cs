using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnLocalPlayerChanged;
    public event Action<int> OnCountdownChanged; // New event for countdown changes

    [SerializeField] private Transform NetworkPlayer;

    public enum State
    {
        Ready,
        GameSceneActive,
        Loading,
        GameOver,
        Start,
        GameCountdown,
    }

    private NetworkVariable<State> currentState = new NetworkVariable<State>(State.Start);
    private NetworkVariable<float> countdownTimer = new NetworkVariable<float>(3f); // Use float for countdown
    private bool isLocalPlayerReady = false;
    private Dictionary<ulong, bool> playerReadyDictionary;

    private void Awake()
    {
        Instance = this;
        playerReadyDictionary = new Dictionary<ulong, bool>();
        if (MultiplayerGameManager.IsServerCustom())
        {
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventCompleted;
        }
        Debug.Log("GameManager: Awake");
    }

    private void Start()
    {
        if (IsServer)
        {
            Debug.Log("GameManager: Server is running");
            currentState.Value = State.Start;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
        Debug.Log("GameManager: Start");
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            // Ensure an entry in the dictionary for each connected client
            foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
            {
                if (!playerReadyDictionary.ContainsKey(clientId))
                {
                    playerReadyDictionary[clientId] = false;
                }
            }
            Debug.Log("GameManager: Initialized playerReadyDictionary for all clients.");
        }
        currentState.OnValueChanged += State_OnValueChanged;
        Debug.Log("GameManager: OnNetworkSpawn");
    }

    public void SceneManager_OnLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        Debug.Log("GameManager: Scene loaded successfully on the server. Spawning players...");

        // Ensure all clients have completed loading
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (!clientsCompleted.Contains(clientId))
            {
                Debug.LogWarning($"GameManager: Client {clientId} has not completed loading.");
                return;
            }
        }

        // Spawn players for all clients
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            Transform playerTransform = Instantiate(NetworkPlayer);
            playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
            Debug.Log($"GameManager: Spawned player for client {clientId}");
        }
    }

    public override void OnNetworkDespawn()
    {
        currentState.OnValueChanged -= State_OnValueChanged;
        Debug.Log("GameManager: OnNetworkDespawn");
    }

    private void State_OnValueChanged(State previousValue, State newValue)
    {
        Debug.Log($"GameManager: State changed from {previousValue} to {newValue}");
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void LocalPlayerReady_OnValueChanged(bool previousValue, bool newValue)
    {
        Debug.Log($"GameManager: Local player ready state changed from {previousValue} to {newValue}");
        OnLocalPlayerChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetGameState(State newState)
    {
        if (IsServer)
        {
            currentState.Value = newState;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
            NotifyClientsOfStateChangeClientRpc(newState);
            Debug.Log($"GameManager: Set game state to {newState}");
        }
    }

    private void Update()
    {
        if (!IsServer)
        {
            return;
        }

        switch (currentState.Value)
        {
            case State.Start:
                // Logic for Start state
                break;
            case State.Ready:
                // Logic for Ready state
                break;
            case State.GameCountdown:
                if (countdownTimer.Value > 0)
                {
                    countdownTimer.Value -= Time.deltaTime; // Decrement using Time.deltaTime
                    NotifyClientsOfCountdownClientRpc(Mathf.CeilToInt(countdownTimer.Value)); // Notify clients with integer value
                    if (countdownTimer.Value <= 0)
                    {
                        SetGameState(State.GameSceneActive);
                    }
                }
                break;
            case State.GameSceneActive:
                // Logic for GameSceneActive state
                break;
            case State.Loading:
                // Logic for LoadingScene state
                break;
            case State.GameOver:
                // Logic for GameOver state
                break;
        }
    }

    public bool IsStateGameScene()
    {
        return currentState.Value == State.GameSceneActive;
    }

    public bool IsStateGameOver()
    {
        return currentState.Value == State.GameOver;
    }

    public bool IsStateLoading()
    {
        return currentState.Value == State.Loading;
    }

    public bool IsStateStart()
    {
        return currentState.Value == State.Start;
    }

    public int GetCountdownValue()
    {
        return Mathf.CeilToInt(countdownTimer.Value); // Return integer value
    }

    public bool IsStateGameCountdown()
    {
        return currentState.Value == State.GameCountdown;
    }

    public bool IsLocalPlayerReady()
    {
        return isLocalPlayerReady;
    }

    public State GetCurrentState()
    {
        return currentState.Value;
    }

    public void SetPlayerReady()
    {
        if (currentState.Value == State.Start)
        {
            isLocalPlayerReady = true;
            SetPlayerReadyServerRpc();
            OnLocalPlayerChanged?.Invoke(this, EventArgs.Empty);
            Debug.Log("GameManager: Local player set to ready");
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default)
    {
        ulong senderClientId = serverRpcParams.Receive.SenderClientId;

        // Check if the sender client ID is in the dictionary, add if missing
        if (!playerReadyDictionary.ContainsKey(senderClientId))
        {
            playerReadyDictionary[senderClientId] = false;
            Debug.LogWarning($"GameManager: Client ID {senderClientId} was missing from the dictionary, added it with default 'false' value.");
            return;
        }

        // Mark the sender client as ready
        playerReadyDictionary[senderClientId] = true;
        Debug.Log($"GameManager: Set client {senderClientId} as ready.");

        // Check readiness for all clients
        bool allClientsReady = true;
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (!playerReadyDictionary.ContainsKey(clientId) || !playerReadyDictionary[clientId])
            {
                allClientsReady = false;
                Debug.Log($"GameManager: Client {clientId} is not ready.");
                break;
            }
        }

        Debug.Log($"GameManager: All clients ready: {allClientsReady}");
        if (allClientsReady)
        {
            SetGameState(State.GameCountdown);
        }
    }

    [ClientRpc]
    private void NotifyClientsOfStateChangeClientRpc(State newState)
    {
        currentState.Value = newState;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log($"GameManager: Notified clients of state change to {newState}");
    }

    [ClientRpc]
    private void NotifyClientsOfCountdownClientRpc(int countdownValue)
    {
        OnCountdownChanged?.Invoke(countdownValue); // Trigger event
        Debug.Log($"GameManager: Notified clients of countdown value {countdownValue}");
    }
}

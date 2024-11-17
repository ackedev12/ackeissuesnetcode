using Unity.Netcode;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Unity.Services.Authentication;
using Unity.Collections;

public class MultiplayerGameManager : NetworkBehaviour
{
    public static MultiplayerGameManager Instance { get; private set; }

    public const int MAX_PLAYERS = 8;
    private const string PLAYER_PREFS_NAME = "PlayerName";

    public event EventHandler OnTryingToJoin;
    public event EventHandler OnFailedToJoin;
    public event EventHandler OnPlayerDataNetworkListChanged;

    private NetworkList<PlayerData> playerDataNetworkList;
    private string playerName;

    private void Awake()
    {
        Debug.Log("MultiplayerGameManager: Awake called.");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            playerName = PlayerPrefs.GetString(PLAYER_PREFS_NAME, "Player " + UnityEngine.Random.Range(100, 1000));
            playerDataNetworkList = new NetworkList<PlayerData>();
            playerDataNetworkList.OnListChanged += PlayerDataNetworkList_OnListChanged;
            Debug.Log("MultiplayerGameManager: NetworkList initialized in Awake.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("MultiplayerGameManager: Duplicate instance destroyed.");
        }
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
        PlayerPrefs.SetString(PLAYER_PREFS_NAME, playerName);
    }

    private void PlayerDataNetworkList_OnListChanged(NetworkListEvent<PlayerData> changeEvent)
    {
        Debug.Log("MultiplayerGameManager: PlayerDataNetworkList_OnListChanged called.");
        OnPlayerDataNetworkListChanged?.Invoke(this, EventArgs.Empty);
    }


    public void StartHost()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += NetworkManager_ConnectionApprovalCallBack;
        NetworkManager.Singleton.OnClientConnectedCallback += NetworkManager_OnClientConnectedCallBack;
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_Server_OnClientDisconnectCallBack;
        NetworkManager.Singleton.StartHost();
        Debug.Log("MultiplayerGameManager: Host created and OnClientConnectedCallback registered.");
    }

    private void NetworkManager_Server_OnClientDisconnectCallBack(ulong clientId)
    {
        for (int i = 0; i < playerDataNetworkList.Count; i++)
        {
            PlayerData playerData = playerDataNetworkList[i];
            if (playerData.clientId == clientId)
            {
                playerDataNetworkList.RemoveAt(i);
                break;
            }
        }
    }

    private void NetworkManager_OnClientConnectedCallBack(ulong clientId)
    {
        Debug.Log($"MultiplayerGameManager: NetworkManager_OnClientConnectedCallBack called for client {clientId}.");

        if (playerDataNetworkList == null)
        {
            Debug.LogError("MultiplayerGameManager: NetworkList is null in OnClientConnectedCallback.");
            return;
        }

        int spawnIndex = playerDataNetworkList.Count;
        string playerName = GetPlayerName();
        playerDataNetworkList.Add(new PlayerData
        {
            clientId = clientId,
            spawnIndex = spawnIndex,
            playerName = playerName
        });
        Debug.Log($"MultiplayerGameManager: Added player data for client {clientId} at index {spawnIndex} with name {playerName}.");

        SetPlayerNameServerRpc(playerName);
        SetPlayerIdServerRpc(AuthenticationService.Instance.PlayerId);
        Debug.Log($"MultiplayerGameManager: Set player name for client {clientId}.");
    }



    private void NetworkManager_ConnectionApprovalCallBack(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        Debug.Log("MultiplayerGameManager: NetworkManager_ConnectionApprovalCallBack called.");

        if (IsServer)
        {
            response.Approved = true;
            Debug.Log("MultiplayerGameManager: Connection approved by server.");
            return;
        }
        if (SceneManager.GetActiveScene().name != SceneLoader.Scene.CharacterSelect.ToString())
        {
            response.Approved = false;
            response.Reason = "Game is already in progress.";
            Debug.Log("MultiplayerGameManager: Connection denied - game in progress.");
            return;
        }

        if (NetworkManager.Singleton.ConnectedClientsList.Count >= MAX_PLAYERS)
        {
            response.Approved = false;
            response.Reason = "Game is full.";
            Debug.Log("MultiplayerGameManager: Connection denied - game is full.");
            return;
        }
        response.Approved = true;
        Debug.Log("MultiplayerGameManager: Connection approved.");
    }

    public void TriggerFailedToJoin()
    {
        Debug.Log("MultiplayerGameManager: TriggerFailedToJoin called.");
        OnFailedToJoin?.Invoke(this, EventArgs.Empty);
    }

    public void StartClient()
    {
        Debug.Log("MultiplayerGameManager: StartClient called.");
        OnTryingToJoin?.Invoke(this, EventArgs.Empty);
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_Client_OnClientDisconnectCallBack;
        NetworkManager.Singleton.OnClientConnectedCallback += NetworkManager_Client_OnClientConnectedCallBack;
        NetworkManager.Singleton.StartClient();
        Debug.Log("MultiplayerGameManager: Joined as a client.");
    }


    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerNameServerRpc(string playerName, ServerRpcParams serverRpcParams = default)
    {
        int playerDataIndex = GetPlayerDataIndexFromClientId(serverRpcParams.Receive.SenderClientId);
        PlayerData playerData = playerDataNetworkList[playerDataIndex];
        playerData.playerName = playerName;
        playerDataNetworkList[playerDataIndex] = playerData;
        Debug.Log($"MultiplayerGameManager: Updated player name for client {serverRpcParams.Receive.SenderClientId} to {playerName}.");
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerIdServerRpc(string playerId, ServerRpcParams serverRpcParams = default)
    {
        int playerDataIndex = GetPlayerDataIndexFromClientId(serverRpcParams.Receive.SenderClientId);
        PlayerData playerData = playerDataNetworkList[playerDataIndex];
        playerData.playerId = playerId;
        playerDataNetworkList[playerDataIndex] = playerData;
        Debug.Log($"MultiplayerGameManager: Updated player name for client {serverRpcParams.Receive.SenderClientId} to {playerName}.");
    }



    private void NetworkManager_Client_OnClientConnectedCallBack(ulong clientId)
    {
        SetPlayerNameServerRpc(GetPlayerName());
        SetPlayerIdServerRpc(AuthenticationService.Instance.PlayerId);
    }

    private void NetworkManager_Client_OnClientDisconnectCallBack(ulong obj)
    {
        OnFailedToJoin?.Invoke(this, EventArgs.Empty);
    }



    public void SelectSkin(int skinIndex)
    {
        Debug.Log($"MultiplayerGameManager: SelectSkin called with skinIndex {skinIndex}.");
        if (IsServer) // Only the server can initiate this
        {
            for (int i = 0; i < playerDataNetworkList.Count; i++)
            {
                var playerData = playerDataNetworkList[i];

                // Find the player data corresponding to the client making the selection
                if (playerData.clientId == NetworkManager.Singleton.LocalClientId)
                {
                    playerData.selectedSkin = skinIndex;
                    playerDataNetworkList[i] = playerData; // Update the list with the modified player data

                    // Notify other clients of the updated skin choice
                    UpdateSkinForClients(playerData);
                    Debug.Log($"MultiplayerGameManager: Updated skin for client {playerData.clientId} to {skinIndex}.");
                    break;
                }
            }
        }
    }

    private void UpdateSkinForClients(PlayerData updatedPlayerData)
    {
        Debug.Log($"MultiplayerGameManager: UpdateSkinForClients called for client {updatedPlayerData.clientId}.");
        // This method will notify clients to update their visual representation
        // You can use a custom RPC or update the NetworkList directly
        int playerIndex = GetPlayerIndex(updatedPlayerData.clientId);
        if (playerIndex != -1)
        {
            playerDataNetworkList[playerIndex] = updatedPlayerData;
        }
        else
        {
            Debug.LogError($"MultiplayerGameManager: PlayerData not found for client {updatedPlayerData.clientId}.");
        }
    }

    public int GetPlayerIndex(ulong clientId)
    {
        Debug.Log($"MultiplayerGameManager: GetPlayerIndex called for client {clientId}.");
        for (int i = 0; i < playerDataNetworkList.Count; i++)
        {
            if (playerDataNetworkList[i].clientId == clientId)
                return i;
        }
        return -1; // Not found
    }

    private void NetworkManager_OnClientDisconnectCallBack(ulong clientId)
    {
        Debug.Log($"MultiplayerGameManager: NetworkManager_OnClientDisconnectCallBack called for client {clientId}.");
        OnFailedToJoin?.Invoke(this, EventArgs.Empty);
    }

    public static bool IsServerCustom()
    {
        bool isServer = NetworkManager.Singleton.IsServer;
        Debug.Log($"MultiplayerGameManager: IsServerCustom called, returning {isServer}.");
        return isServer;
    }

    public bool IsPlayerIndexConnected(int playerIndex)
    {
        bool isConnected = playerIndex >= 0 && playerIndex < playerDataNetworkList.Count;
        Debug.Log($"MultiplayerGameManager: IsPlayerIndexConnected called for index {playerIndex}, returning {isConnected}.");
        return isConnected;
    }

    public NetworkList<PlayerData> GetPlayerDataList()
    {
        Debug.Log("MultiplayerGameManager: GetPlayerDataList called.");
        return playerDataNetworkList;
    }

    public PlayerData GetPlayerDataFromPlayerIndex(int playerIndex)
    {
        Debug.Log($"MultiplayerGameManager: GetPlayerDataFromPlayerIndex called for index {playerIndex}.");
        if (playerIndex >= 0 && playerIndex < playerDataNetworkList.Count)
        {
            return playerDataNetworkList[playerIndex];
        }
        throw new IndexOutOfRangeException($"PlayerData not found for index {playerIndex}");
    }

    public int GetPlayerDataIndexFromClientId(ulong clientId)
    {
        Debug.Log($"MultiplayerGameManager: GetPlayerDataIndexFromClientId called for client {clientId}.");
        for (int i = 0; i < playerDataNetworkList.Count; i++)
        {
            if (playerDataNetworkList[i].clientId == clientId)
                return i;
        }
        return -1; // Not found
    }

    public ulong GetClientId(int playerIndex)
    {
        Debug.Log($"MultiplayerGameManager: GetClientId called for player index {playerIndex}.");
        if (playerIndex >= 0 && playerIndex < playerDataNetworkList.Count)
        {
            return playerDataNetworkList[playerIndex].clientId;
        }
        return 0;
    }

    public void UpdatePlayerData(int playerIndex, PlayerData updatedPlayerData)
    {
        if (playerIndex >= 0 && playerIndex < playerDataNetworkList.Count)
        {
            playerDataNetworkList[playerIndex] = updatedPlayerData;
            Debug.Log($"MultiplayerGameManager: Updated player data for index {playerIndex} with skin {updatedPlayerData.selectedSkin}");
        }
        else
        {
            Debug.LogError($"Invalid player index {playerIndex} for updating PlayerData.");
        }
    }

    public void KickPlayer(ulong clientId)
    {
        // Ensure that this method can only be called by the server
        if (!IsServer)
        {
            Debug.LogWarning("KickPlayer can only be called by the server.");
            return;
        }

        // Find the player index in the NetworkList
        int playerIndex = GetPlayerIndex(clientId);
        if (playerIndex != -1)
        {
            // Remove the player from the NetworkList
            playerDataNetworkList.RemoveAt(playerIndex);
        }

        // Disconnect the client
        NetworkManager.Singleton.DisconnectClient(clientId);
        Debug.Log($"Player with ID {clientId} has been kicked and disconnected.");

        // Ensure that the player's NetworkObject is despawned
        if (NetworkManager.Singleton.ConnectedClients.TryGetValue(clientId, out var client))
        {
            NetworkObject playerNetworkObject = client.PlayerObject;
            if (playerNetworkObject != null)
            {
                playerNetworkObject.Despawn(true);
            }
        }
    }
}

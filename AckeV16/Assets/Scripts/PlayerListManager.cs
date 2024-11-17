using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using System.Collections.Generic;

public class PlayerListManager : NetworkBehaviour
{
    [SerializeField] private GameObject playerEntryPrefab; // Reference to the player entry prefab
    [SerializeField] private Transform playerListPanel; // Reference to the panel where player entries are displayed

    private Dictionary<ulong, GameObject> playerEntries = new Dictionary<ulong, GameObject>();

    private void OnEnable()
    {
        Debug.Log("PlayerListManager enabled");
        // Subscribe to player data changes
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void OnDisable()
    {
        Debug.Log("PlayerListManager disabled");
        // Unsubscribe when disabled
        NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsServer)
        {
            Debug.Log("OnNetworkSpawn called on server");
            UpdatePlayerList();
        }
        else
        {
            // Hide the player list panel for clients
            playerListPanel.gameObject.SetActive(false);
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client connected: {clientId}");
        if (IsServer)
        {
            RequestPlayerDataClientRpc(clientId);
        }
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"Client disconnected: {clientId}");
        if (IsServer)
        {
            // Remove the player entry from the dictionary and destroy the GameObject
            if (playerEntries.TryGetValue(clientId, out GameObject entry))
            {
                Destroy(entry);
                playerEntries.Remove(clientId);
            }
            UpdatePlayerList();
        }
    }

    private void UpdatePlayerList()
    {
        if (!IsServer) return; // Only the server should update the player list

        Debug.Log("Updating player list...");

        // Clear existing entries
        foreach (var entry in playerEntries.Values)
        {
            Destroy(entry);
        }
        playerEntries.Clear();

        // Iterate over player data indices and create entries
        for (int playerIndex = 0; playerIndex < MultiplayerGameManager.Instance.GetPlayerDataList().Count; playerIndex++)
        {
            ulong clientId = MultiplayerGameManager.Instance.GetClientId(playerIndex);
            Debug.Log($"Creating entry for clientId: {clientId} at playerIndex: {playerIndex}");
            CreatePlayerEntry(clientId);
        }
    }

    private void CreatePlayerEntry(ulong clientId)
    {
        Debug.Log($"Creating player entry for clientId: {clientId}");

        // Instantiate the entry under the playerListPanel
        GameObject entry = Instantiate(playerEntryPrefab, playerListPanel);

        // Get the PlayerEntry component and set the name
        PlayerEntry playerEntry = entry.GetComponent<PlayerEntry>();
        UpdatePlayerEntry(clientId, playerEntry);

        // Store the entry in the dictionary
        playerEntries[clientId] = entry;

        // Force the layout to rebuild immediately
        LayoutRebuilder.ForceRebuildLayoutImmediate(playerListPanel.GetComponent<RectTransform>());
    }

    private void UpdatePlayerEntry(ulong clientId, PlayerEntry playerEntry)
    {
        // Fetch the player index from MultiplayerGameManager
        int playerIndex = MultiplayerGameManager.Instance.GetPlayerDataIndexFromClientId(clientId);
        Debug.Log($"UpdatePlayer: PlayerIndex = {playerIndex}");

        if (MultiplayerGameManager.Instance.IsPlayerIndexConnected(playerIndex))
        {
            // Fetch the player data
            PlayerData playerData = MultiplayerGameManager.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
            Debug.Log($"FETCHED PLAYER DATA FOR CLIENTID: {clientId}, PLAYERDATA: {playerData.ToString().ToUpper()}");
            string playerName = playerData.playerName.ToString();
            playerEntry.Initialize(this, clientId, playerName);
            Debug.Log($"SET PLAYER NAME TO {playerName.ToUpper()} FOR CLIENTID: {clientId}");
        }
        else
        {
            Debug.LogError($"PLAYER INDEX NOT CONNECTED FOR CLIENTID: {clientId}");
        }
    }

    public void KickPlayer(ulong clientId)
    {
        Debug.Log($"Kicking player with clientId: {clientId}");
        KickPlayerServerRpc(clientId);
    }

    [ServerRpc(RequireOwnership = false)]
    private void KickPlayerServerRpc(ulong clientId)
    {
        if (IsServer)
        {
            // Notify the client to load the main menu
            NotifyClientKickedClientRpc(clientId);

            // Implement the logic to kick the player
            NetworkManager.Singleton.DisconnectClient(clientId);
            MultiplayerGameManager.Instance.KickPlayer(clientId);

            // Remove the player entry from the dictionary and destroy the GameObject
            if (playerEntries.TryGetValue(clientId, out GameObject entry))
            {
                Destroy(entry);
                playerEntries.Remove(clientId);
            }
        }
    }

    [ClientRpc]
    private void NotifyClientKickedClientRpc(ulong clientId)
    {
        if (NetworkManager.Singleton.LocalClientId == clientId)
        {
            // Load the main menu scene
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
        }
    }

    [ClientRpc]
    private void RequestPlayerDataClientRpc(ulong clientId)
    {
        if (NetworkManager.Singleton.LocalClientId == clientId)
        {
            SendPlayerDataServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void SendPlayerDataServerRpc(ServerRpcParams rpcParams = default)
    {
        ulong clientId = rpcParams.Receive.SenderClientId;
        int playerIndex = MultiplayerGameManager.Instance.GetPlayerDataIndexFromClientId(clientId);
        PlayerData playerData = MultiplayerGameManager.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
        Debug.Log($"Received player data from clientId: {clientId}, playerName: {playerData.playerName}");

        // Update the player entry with the received data
        if (playerEntries.TryGetValue(clientId, out GameObject entry))
        {
            PlayerEntry playerEntry = entry.GetComponent<PlayerEntry>();
            playerEntry.Initialize(this, clientId, playerData.playerName.ToString());
        }
        else
        {
            CreatePlayerEntry(clientId);
        }
    }
}

using UnityEngine;
using Unity.Netcode;
using System;
using System.Collections.Generic;

public class CharacterSelectionManager : NetworkBehaviour
{
    public static CharacterSelectionManager Instance { get; private set; }

    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject defaultCharacterPrefab;
    [SerializeField] private GameObject loadingUI;

    private Dictionary<ulong, GameObject> spawnedCharacters = new Dictionary<ulong, GameObject>();
    private Dictionary<ulong, bool> playerReadyState = new Dictionary<ulong, bool>();
    private HashSet<int> takenSpawnIndices = new HashSet<int>();

    public event EventHandler OnReadyChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        loadingUI.SetActive(false); // Ensure loading UI is disabled at start
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            InitializeManager();
        }
    }

    private void InitializeManager()
    {
        Debug.Log("CharacterSelectionManager: Initializing on Server.");
        MultiplayerGameManager.Instance.OnPlayerDataNetworkListChanged += OnPlayerDataNetworkListChanged;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnect;
        InitializeSpawnPositions();
        UpdatePlayerSpawns(); // Call once to initialize current players on start
    }

    private void OnPlayerDataNetworkListChanged(object sender, EventArgs e)
    {
        if (IsServer)
        {
            Debug.Log("CharacterSelectionManager: Player data network list changed.");
            UpdatePlayerSpawns();
        }
    }

    private void InitializeSpawnPositions()
    {
        Debug.Log("CharacterSelectionManager: Initializing spawn positions.");
        // Set up the spawn positions if needed
    }

    private void UpdatePlayerSpawns()
    {
        var playerDataList = MultiplayerGameManager.Instance.GetPlayerDataList();
        Debug.Log($"CharacterSelectionManager: Updating player spawns. Player count: {playerDataList.Count}");

        for (int i = 0; i < playerDataList.Count; i++)
        {
            SpawnCharacterForPlayer(playerDataList[i].clientId);
        }
    }

    private void SpawnCharacterForPlayer(ulong clientId)
    {
        if (spawnedCharacters.ContainsKey(clientId))
        {
            Debug.Log($"CharacterSelectionManager: Character already spawned for client {clientId}.");
            return;
        }

        int playerIndex = MultiplayerGameManager.Instance.GetPlayerDataIndexFromClientId(clientId);
        if (playerIndex == -1)
        {
            Debug.LogWarning($"CharacterSelectionManager: PlayerData not found for client {clientId}.");
            return;
        }

        var playerData = MultiplayerGameManager.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
        if (playerData.spawnIndex < spawnPositions.Length)
        {
            Transform spawnTransform = spawnPositions[playerData.spawnIndex];
            GameObject character = Instantiate(defaultCharacterPrefab, spawnTransform.position, spawnTransform.rotation);
            Debug.Log($"CharacterSelectionManager: Instantiated character for client {clientId} at spawn index {playerData.spawnIndex}.");

            NetworkObject characterNetworkObject = character.GetComponent<NetworkObject>();
            if (characterNetworkObject != null)
            {
                characterNetworkObject.SpawnAsPlayerObject(clientId, true);
                Debug.Log($"CharacterSelectionManager: Spawned NetworkObject for client {clientId} with NetworkObjectId {characterNetworkObject.NetworkObjectId}.");
            }

            spawnedCharacters[clientId] = character;
            takenSpawnIndices.Add(playerData.spawnIndex);
        }
        else
        {
            Debug.LogWarning($"CharacterSelectionManager: Spawn index {playerData.spawnIndex} out of range for client {clientId}.");
        }
    }

    public void DespawnCharacter(ulong clientId)
    {
        if (IsServer && spawnedCharacters.ContainsKey(clientId))
        {
            GameObject character = spawnedCharacters[clientId];
            if (character == null)
            {
                Debug.LogWarning($"CharacterSelectionManager: Character GameObject for client {clientId} is already null.");
                spawnedCharacters.Remove(clientId);
                return;
            }

            NetworkObject networkObject = character.GetComponent<NetworkObject>();
            if (networkObject != null)
            {
                Debug.Log($"CharacterSelectionManager: Despawning NetworkObject for client {clientId} with NetworkObjectId {networkObject.NetworkObjectId}.");
                networkObject.Despawn(true); // Ensure the object is despawned and destroyed
            }
            else
            {
                Debug.LogWarning($"CharacterSelectionManager: No NetworkObject found for client {clientId}.");
            }

            spawnedCharacters.Remove(clientId);
        }
        else
        {
            Debug.LogWarning($"CharacterSelectionManager: No character found to despawn for client {clientId}.");
        }
    }

    private void DespawnAllCharacters()
    {
        if (IsServer)
        {
            // Clear the dictionary and hashset without despawning the characters
            spawnedCharacters.Clear();
            takenSpawnIndices.Clear();
        }
    }

    public void SetPlayerReady()
    {
        SetPlayerReadyServerRpc();
        OnReadyChanged?.Invoke(this, EventArgs.Empty);
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default)
    {
        ulong clientId = serverRpcParams.Receive.SenderClientId;
        playerReadyState[clientId] = true;

        // Notify all clients about the ready state change
        UpdateReadyStateClientRpc(clientId, true);

        bool allClientsReady = true;
        foreach (ulong id in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (!playerReadyState.ContainsKey(id) || !playerReadyState[id])
            {
                allClientsReady = false;
                break;
            }
        }
        if (allClientsReady)
        {
            ShowLoadingUIClientRpc();
            DespawnAllCharacters();
            LobbyManager.Instance.DeleteLobby(); // Delete the lobby after all players are ready
            SceneLoader.LoadNetwork(SceneLoader.Scene.GameScene);
        }
        Debug.Log("All players: " + allClientsReady);
    }

    [ClientRpc]
    private void ShowLoadingUIClientRpc()
    {
        loadingUI.SetActive(true);
    }

    [ClientRpc]
    private void UpdateReadyStateClientRpc(ulong clientId, bool isReady)
    {
        if (playerReadyState.ContainsKey(clientId))
        {
            playerReadyState[clientId] = isReady;
        }
        else
        {
            playerReadyState.Add(clientId, isReady);
        }

        // Trigger the OnReadyChanged event on the client side
        OnReadyChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool IsPlayerReady(ulong clientId)
    {
        return playerReadyState.ContainsKey(clientId) && playerReadyState[clientId];
    }

    private void OnClientDisconnect(ulong clientId)
    {
        if (IsServer)
        {
            if (playerReadyState.ContainsKey(clientId))
            {
                playerReadyState.Remove(clientId);
            }

            if (spawnedCharacters.ContainsKey(clientId))
            {
                DespawnCharacter(clientId);
            }
        }
    }

    public override void OnDestroy()
    {
        if (IsServer)
        {
            MultiplayerGameManager.Instance.OnPlayerDataNetworkListChanged -= OnPlayerDataNetworkListChanged;
            NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnect;
        }
        base.OnDestroy();
    }
}

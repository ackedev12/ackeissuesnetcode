using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyNetworkManager : NetworkManager
{
    public Transform[] spawnPoints; // Array of spawn points  
    [SerializeField]
    public GameObject playerPrefab; // Add this line to declare playerPrefab

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (IsServer)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        if (IsHost)
        {
            int spawnIndex = (int)clientId % spawnPoints.Length;
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            player.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
        }
    }

    private void SceneLoaded(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        if (IsHost && sceneName == "Game")
        {
            int spawnIndex = 0;
            foreach (NetworkClient client in NetworkManager.Singleton.ConnectedClientsList)
            {
                if (client.PlayerObject == null)
                {
                    Transform spawnPoint = spawnPoints[spawnIndex % spawnPoints.Length];
                    GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
                    player.GetComponent<NetworkObject>().SpawnAsPlayerObject(client.ClientId, true);
                    spawnIndex++;
                }
            }
        }
    }
}


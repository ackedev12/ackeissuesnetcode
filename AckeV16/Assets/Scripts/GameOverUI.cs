using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button exitToLobby;
    [SerializeField] private Button exitGame; // Reference to LocalUIManager
    [SerializeField] private GameObject gameOverUI;

    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnDisconnectedCallback;

    }

    private void Awake()
    {
        exitToLobby.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            // hanle loading the lobby scene
        });

        exitGame.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void NetworkManager_OnDisconnectedCallback(ulong clientId)
    {
        if (clientId == NetworkManager.ServerClientId)
        {
            // Server disconnecteds
            // Show the exit to lobby button
            gameOverUI.gameObject.SetActive(true);
        }
    }
}

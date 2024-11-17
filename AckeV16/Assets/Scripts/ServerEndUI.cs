using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ServerEndUI : MonoBehaviour
{
    [SerializeField] private Button exitToLobby;
    [SerializeField] private Button exitGame; // Reference to LocalUIManager
    [SerializeField] private GameObject serverEndUI;

    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnDisconnectedCallback;
        serverEndUI.gameObject.SetActive(false);

    }

    private void Awake()
    {
        exitToLobby.onClick.AddListener(() =>
        {
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
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
            // Server disconnected
            // Show the exit to lobby button
            serverEndUI.gameObject.SetActive(true);
        }
    }
}

using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        MultiplayerGameManager.Instance.OnFailedToJoin += MultiplayerGameManager_OnFailedToJoin;
        LobbyManager.Instance.OnCreateLobbyStarted += LobbyManager_OnCreateLobbyStarted;
        LobbyManager.Instance.OnCreateLobbyFailed += LobbyManager_OnCreateLobbyFailed;
        LobbyManager.Instance.OnJoinStarted += LobbyManager_OnJoinStarted;
        LobbyManager.Instance.OnJoinFailed += LobbyManager_OnJoinFailed;
        LobbyManager.Instance.OnQuickJoinFailed += LobbyManager_OnQuickJoinFailed;

        Hide();
    }


    private void LobbyManager_OnQuickJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Could not find a Lobby to quick join");
    }

    private void LobbyManager_OnJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to join lobby");
    }

    private void LobbyManager_OnJoinStarted(object sender, EventArgs e)
    {
        ShowMessage("Joining lobby...");
    }

    private void LobbyManager_OnCreateLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to create lobby");
    }

    private void LobbyManager_OnCreateLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Creating lobby...");
    }

    private void ShowMessage(string message)
    {
        Show();
        messageText.text = message;
    }

    private void MultiplayerGameManager_OnFailedToJoin(object sender, EventArgs e)
    {
        string message;
        message = NetworkManager.Singleton.DisconnectReason;
        if (string.IsNullOrEmpty(message))
        {
            messageText.text = "Failed to connect";
        }

        ShowMessage(message);

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void OnDestroy()
    {
        MultiplayerGameManager.Instance.OnFailedToJoin -= MultiplayerGameManager_OnFailedToJoin;
        LobbyManager.Instance.OnCreateLobbyStarted -= LobbyManager_OnCreateLobbyStarted;
        LobbyManager.Instance.OnCreateLobbyStarted -= LobbyManager_OnCreateLobbyFailed;
        LobbyManager.Instance.OnJoinStarted -= LobbyManager_OnJoinStarted;
        LobbyManager.Instance.OnJoinFailed -= LobbyManager_OnJoinFailed;
        LobbyManager.Instance.OnQuickJoinFailed -= LobbyManager_OnQuickJoinFailed;
        base.OnDestroy();
    }
}

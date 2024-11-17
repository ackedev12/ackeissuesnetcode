using UnityEngine;
using TMPro; // Add this line to use TextMeshPro
using UnityEngine.UI;

public class PlayerEntry : MonoBehaviour
{
    public TextMeshProUGUI PlayerNameText; // Change Text to TextMeshProUGUI
    public Button KickButton; // Assign in Inspector

    private ulong clientId;
    private PlayerListManager playerListManager;

    public void Initialize(PlayerListManager manager, ulong id, string playerName)
    {
        playerListManager = manager;
        clientId = id;
        PlayerNameText.text = playerName;

        // Add a listener for the kick button
        KickButton.onClick.AddListener(OnKickButtonClicked);
    }

    private void OnKickButtonClicked()
    {
        // Retrieve the PlayerData instance from MultiplayerGameManager
        int playerIndex = MultiplayerGameManager.Instance.GetPlayerDataIndexFromClientId(clientId);
        if (playerIndex != -1)
        {
            PlayerData playerData = MultiplayerGameManager.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
            LobbyManager.Instance.KickPlayer(playerData.playerId.ToString()); // Kick the player
            MultiplayerGameManager.Instance.KickPlayer(playerData.clientId); // Kick the player
        }
        playerListManager.KickPlayer(clientId);
    }
}

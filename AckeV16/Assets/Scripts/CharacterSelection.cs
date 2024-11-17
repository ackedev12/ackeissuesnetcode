using System.Collections;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using Unity.Collections;

public class CharacterSelection : NetworkBehaviour
{
    [SerializeField] private GameObject readyUpText;
    [SerializeField] private TextMeshPro playerNameText;

    private void Start()
    {
        if (MultiplayerGameManager.Instance == null)
        {
            Debug.LogError("MultiplayerGameManager instance is not available.");
            return;
        }

        MultiplayerGameManager.Instance.OnPlayerDataNetworkListChanged += MultiplayerGameManager_OnPlayerDataNetworkListChanged;
        CharacterSelectionManager.Instance.OnReadyChanged += CharacterSelectionManager_OnReadyChanged;

        UpdatePlayer();
    }

    private void MultiplayerGameManager_OnPlayerDataNetworkListChanged(object sender, System.EventArgs e)
    {
        UpdatePlayer();
    }

    private void CharacterSelectionManager_OnReadyChanged(object sender, System.EventArgs e)
    {
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {
        // Re-fetch player data to ensure the latest data is used
        ulong clientId = OwnerClientId;
        Debug.Log($"UpdatePlayer: OwnerClientId = {clientId}");

        int playerIndex = MultiplayerGameManager.Instance.GetPlayerDataIndexFromClientId(clientId);
        Debug.Log($"UpdatePlayer: PlayerIndex = {playerIndex}");

        if (MultiplayerGameManager.Instance.IsPlayerIndexConnected(playerIndex))
        {
            Show();
            PlayerData playerData = MultiplayerGameManager.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
            playerNameText.text = playerData.playerName.ToString();
            readyUpText.SetActive(CharacterSelectionManager.Instance.IsPlayerReady(clientId));
            Debug.Log($"CharacterSelection: Updating player with skin {playerData.selectedSkin}");
            UpdateCharacterAppearance(playerData.selectedSkin);
        }
        else
        {
            Debug.LogError("PlayerData not found or player is not connected.");
            Hide();
        }
    }

    private void UpdateCharacterAppearance(int selectedSkin)
    {
        // Update the character's appearance based on the selected skin
        switch (selectedSkin)
        {
            case 0:
                // Apply default appearance
                break;
            case 1:
                // Apply skin 1
                break;
            case 2:
                // Apply skin 2
                break;
            default:
                Debug.LogWarning($"Unknown customization {selectedSkin}");
                break;
        }
    }

    public void SelectSkin(int skinIndex)
    {
        UpdateCharacterAppearance(skinIndex);
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
        if (MultiplayerGameManager.Instance != null)
        {
            MultiplayerGameManager.Instance.OnPlayerDataNetworkListChanged -= MultiplayerGameManager_OnPlayerDataNetworkListChanged;
        }

        if (CharacterSelectionManager.Instance != null)
        {
            CharacterSelectionManager.Instance.OnReadyChanged -= CharacterSelectionManager_OnReadyChanged;
        }
        base.OnDestroy();
    }
}

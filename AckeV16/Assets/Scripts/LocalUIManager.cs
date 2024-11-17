using System;
using UnityEngine;
using UnityEngine.UI;

public class LocalUIManager : MonoBehaviour
{
    [SerializeField] private GameObject countdownPanel; // Reference to the countdown panel
    [SerializeField] private GameObject readyPanel; // Reference to the ready panel
    [SerializeField] private Button readyButton; // Reference to the ready button
    [SerializeField] private GameObject mainGameStateUI; // Reference to the main game state UI
    [SerializeField] private GameObject gameOverUI; // Reference to the game over UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        GameManager.Instance.OnLocalPlayerChanged += GameManager_OnLocalPlayerChanged;
        GameManager.Instance.OnCountdownChanged += GameManager_OnCountdownChanged;
        UpdateVisuals(); // Initial call to set the correct state
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStateChanged -= GameManager_OnStateChanged;
        GameManager.Instance.OnLocalPlayerChanged -= GameManager_OnLocalPlayerChanged;
        GameManager.Instance.OnCountdownChanged -= GameManager_OnCountdownChanged;
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        UpdateVisuals();
    }

    private void GameManager_OnLocalPlayerChanged(object sender, EventArgs e)
    {
        UpdateVisuals();
    }

    private void GameManager_OnCountdownChanged(int countdownValue)
    {
        // Handle countdown value change if needed
    }

    public void SetReadyToggle()
    {
        if (!GameManager.Instance.IsLocalPlayerReady())
        {
            GameManager.Instance.SetPlayerReady();
        }
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        // Activate the appropriate UI elements based on the game state
        switch (GameManager.Instance.GetCurrentState())
        {
            case GameManager.State.Start:
                readyPanel.SetActive(GameManager.Instance.IsLocalPlayerReady());
                readyButton.gameObject.SetActive(!GameManager.Instance.IsLocalPlayerReady());
                countdownPanel.SetActive(false);
                mainGameStateUI.SetActive(false);
                gameOverUI.SetActive(false);
                break;

            case GameManager.State.GameCountdown:
                countdownPanel.SetActive(true);
                readyPanel.SetActive(false);
                readyButton.gameObject.SetActive(false);
                mainGameStateUI.SetActive(false);
                gameOverUI.SetActive(false);
                break;

            case GameManager.State.GameSceneActive:
                mainGameStateUI.SetActive(true);
                readyPanel.SetActive(false);
                readyButton.gameObject.SetActive(false);
                countdownPanel.SetActive(false);
                gameOverUI.SetActive(false);
                break;

            case GameManager.State.GameOver:
                gameOverUI.SetActive(true);
                readyPanel.SetActive(false);
                readyButton.gameObject.SetActive(false);
                countdownPanel.SetActive(false);
                mainGameStateUI.SetActive(false);
                break;

                // Add other states if needed
        }
    }
}

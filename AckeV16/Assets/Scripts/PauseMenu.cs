using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI; // Assign your PauseMenu Canvas in the Inspector
    [SerializeField] public SettingsUI settingsMenuUI;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitToLobbyButton;

    public static bool isPaused = false;
    public PlayerInput playerInput;

    private void Start()
    {
        // Hide the pause menu UI initially
        SetChildrenActive(pauseMenuUI, false);

        // Set isPaused to false initially
        isPaused = false;
    }

    private void Awake()
    {
        // Add listeners to the buttons
        resumeButton.onClick.AddListener(() => {
            Resume();
        });

        settingsButton.onClick.AddListener(() => {
            SetChildrenActive(pauseMenuUI, false);    // Hide all children of pause menu UI
            settingsMenuUI.Show();  // Show all children of settings menu UI
        });

        exitToLobbyButton.onClick.AddListener(() => {
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
            NetworkManager.Singleton.Shutdown();
            // handle loading the lobby scene
        });
    }

    private void Show()
    {
        SetChildrenActive(pauseMenuUI, true);
    }

    private void Hide()
    {
        SetChildrenActive(pauseMenuUI, false);
    }

    public void SetChildrenActive(GameObject parent, bool isActive)
    {
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }

    public void Resume()
    {
        Hide();    // Hide pause menu UI
        // Resume game time
        isPaused = false;
        Cursor.visible = false;          // Hide cursor
        Cursor.lockState = CursorLockMode.Locked;  // Lock cursor
        playerInput.enabled = true;
    }

    public void Pause()
    {
        Show();     // Show pause menu UI
        // Pause game time
        isPaused = true;
        Cursor.visible = true;           // Show cursor
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        playerInput.enabled = false;
    }
}

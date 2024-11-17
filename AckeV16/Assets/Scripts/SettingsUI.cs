using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{

    [SerializeField] private GameObject settingsUI;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private Button exitSettingsButton;
    public PlayerInput playerInput;
    public bool settingsOpen;


    private void Awake()
    {
        // find the pausemenu component in the scene
        settingsOpen = false;
        exitSettingsButton.onClick.AddListener(() => {
            Hide();
            pauseMenu.SetChildrenActive(pauseMenu.gameObject, true);
        });
    }
    private void Start()
    {
        // Hide the pause menu UI initially

        Hide();
    }

    public void Show()
    {
        settingsOpen = true;
        pauseMenu.SetChildrenActive(settingsUI, true);
        
    }

    public void Hide()
    {
        settingsOpen = false;
        pauseMenu.SetChildrenActive(settingsUI, false);
    }
}

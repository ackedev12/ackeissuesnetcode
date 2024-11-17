using UnityEngine;
using UnityEngine.UI;

public class MenuSettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private Button exitSettingsButton;
    [SerializeField] private Button enterSettingsButton;
    public bool settingsOpen;

    private void Awake()
    {
        settingsOpen = false;
        enterSettingsButton.onClick.AddListener(Show);
        exitSettingsButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        // Hide the settings UI initially
        Hide();
    }

    public void Show()
    {
        settingsOpen = true;
        settingsUI.SetActive(true);
    }

    public void Hide()
    {
        settingsOpen = false;
        settingsUI.SetActive(false);
    }
}

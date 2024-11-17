using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    [SerializeField] private Button readyButton;
    [SerializeField] private LocalUIManager localUIManager; // Reference to LocalUIManager

    private void Start()
    {
        if (readyButton == null)
        {
            readyButton = GetComponent<Button>();
        }
        readyButton.onClick.AddListener(OnReadyButtonClicked);
    }

    private void OnReadyButtonClicked()
    {
        if (localUIManager != null)
        {
            localUIManager.SetReadyToggle(); // Mark the player as ready and update UI
        }
        else
        {
            Debug.LogError("LocalUIManager component is not assigned.");
        }
    }
}

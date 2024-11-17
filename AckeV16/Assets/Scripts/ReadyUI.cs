using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class ReadyUI : MonoBehaviour
{
    [SerializeField] private GameObject readyPanel; // Reference to the ready panel
    [SerializeField] private Button readyButton; // Reference to the ready button

    private void Start()
    {
        GameManager.Instance.OnStateChanged += Gamemanager_OnGameStateChanged;
        GameManager.Instance.OnLocalPlayerChanged += Gamemanager_OnLocalPlayerChanged;
        UpdateVisual();
    }

    private void Gamemanager_OnGameStateChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void Gamemanager_OnLocalPlayerChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (GameManager.Instance.IsLocalPlayerReady() && GameManager.Instance.IsStateStart())
        {
            readyPanel.SetActive(true);
            readyButton.gameObject.SetActive(false);
        }
        else
        {
            readyPanel.SetActive(false);
            if (GameManager.Instance.IsStateStart())
            {
                readyButton.gameObject.SetActive(true);
            }
            else
            {
                readyButton.gameObject.SetActive(false);
            }
        }
    }

    public void ToggleReadyState()
    {
        if (!GameManager.Instance.IsLocalPlayerReady())
        {
            GameManager.Instance.SetPlayerReady();
        }
        UpdateVisual();
    }
}

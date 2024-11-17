using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateLobbyUI : MonoBehaviour
{
    [SerializeField] private Button createPublicLobby;
    [SerializeField] private Button createPrivateLobby;
    [SerializeField] private Button closeButton;
    [SerializeField] private TMP_InputField lobbyNameInputField;

    private void Awake()
    {
        createPublicLobby.onClick.AddListener(() => {
            LobbyManager.Instance.CreateLobby(lobbyNameInputField.text, false);
        });
        createPrivateLobby.onClick.AddListener(() => {
            LobbyManager.Instance.CreateLobby(lobbyNameInputField.text, true);
        });
        closeButton.onClick.AddListener(() => { Hide(); });
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button ClientButton;
    [SerializeField] private Button ServerButton;
    [SerializeField] private Button HostButton;

    private void Awake()
    {
        ClientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
        HostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        ServerButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
    }
}

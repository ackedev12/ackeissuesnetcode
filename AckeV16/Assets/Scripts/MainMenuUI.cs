using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitGameButton;
    //[SerializeField] private Button settingsButton;

    private void Awake()
    {
        startButton.onClick.AddListener(() => { SceneLoader.LoadScene(SceneLoader.Scene.LobbyScene); });
        exitGameButton.onClick.AddListener(() => { Application.Quit(); });
        //settingsButton.onClick.AddListener(() => { });
    }
}

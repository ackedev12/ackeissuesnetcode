using System;
using UnityEngine;
using Unity.Netcode;

public class ConnectingUI : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MultiplayerGameManager.Instance.OnTryingToJoin += MultiplayerGameManager_OnTryToJoin;
        MultiplayerGameManager.Instance.OnFailedToJoin += MultiplayerGameManager_OnFailedToJoin;
        Hide();
    }

    private void MultiplayerGameManager_OnFailedToJoin(object sender, EventArgs e)
    {
        Hide();
    }

    private void MultiplayerGameManager_OnTryToJoin(object sender, EventArgs e)
    {
        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide() {
        gameObject.SetActive(false);
    }
    public override void OnDestroy()
    {
        MultiplayerGameManager.Instance.OnFailedToJoin -= MultiplayerGameManager_OnFailedToJoin;
        MultiplayerGameManager.Instance.OnTryingToJoin -= MultiplayerGameManager_OnTryToJoin;
        base.OnDestroy();
    }
}

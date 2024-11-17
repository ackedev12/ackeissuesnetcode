using System;
using UnityEngine;
using UnityEngine.UI;

public class MainGameStateUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        GameManager.Instance.OnCountdownChanged += GameManager_OnCountdownChanged; // Subscribe to countdown changes
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        // No need to update visuals here, handled by GameManager
    }

    private void GameManager_OnCountdownChanged(int countdownValue)
    {
        // No need to update visuals here, handled by GameManager
    }
}

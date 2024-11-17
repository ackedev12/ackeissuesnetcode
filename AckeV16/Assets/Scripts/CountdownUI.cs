using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText; // Change the type to TextMeshProUGUI
    [SerializeField] private GameObject countdownPanel; // Add a reference to the countdown panel

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        GameManager.Instance.OnCountdownChanged += GameManager_OnCountdownChanged; // Subscribe to countdown changes
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsStateGameCountdown())
        {
            StartCoroutine(UpdateCountdown());
        }
    }

    private void GameManager_OnCountdownChanged(int countdownValue)
    {
        countdownText.text = countdownValue.ToString();
    }

    private IEnumerator UpdateCountdown()
    {
        while (GameManager.Instance.IsStateGameCountdown())
        {
            countdownText.text = GameManager.Instance.GetCountdownValue().ToString();
            yield return null; // Check every frame
        }
    }
}

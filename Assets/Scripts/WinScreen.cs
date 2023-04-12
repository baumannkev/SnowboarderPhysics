using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreenPanel;
    public TextMeshProUGUI rotationsText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI airTimeText;
    public TextMeshProUGUI maxVelocityText;
    public TextMeshProUGUI totalPointsText;
    
    public PlayerController player;
    public Timer timer;

    private void Start()
    {
        winScreenPanel.SetActive(false);
    }

    private void Update()
    {
        if (timer.isFinished && !winScreenPanel.activeSelf)
        {
            ShowWinScreen();
        }
    }

    public void ShowWinScreen()
    {
        winScreenPanel.SetActive(true);
        rotationsText.text = $"Rotations: {player.totalRotations}";
        timeText.text = $"Time: {timer.timeElapsed:0.00} s";
        airTimeText.text = $"Total Air Time: {player.totalAirTime:0.00} s";
        maxVelocityText.text = $"Max Velocity: {player.GetMaxVelocity()} m/s";
        totalPointsText.text = $"Points: {player.totalPoints}";
    }
}

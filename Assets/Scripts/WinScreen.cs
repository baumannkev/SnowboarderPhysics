using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreenPanel;
    public TextMeshProUGUI rotationsText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI airTimeText;
    public TextMeshProUGUI maxVelocityText;
    public TextMeshProUGUI totalPointsText;
    public TextMeshProUGUI totalCoinsCountText;
    
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
        
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         
         if (currentSceneIndex == 1){
             
             string highScoreKey = "HighScore";
             float currentHighScore = PlayerPrefs.GetFloat(highScoreKey, 0);

             if (player.totalPoints > currentHighScore)
             {
                 totalPointsText.text = $"NEW HIGH SCORE\nPoints: {player.totalPoints}";
                 PlayerPrefs.SetFloat(highScoreKey, player.totalPoints);
                 PlayerPrefs.Save(); // Don't forget to save the changes
             } else{
            
                 totalPointsText.text = $"Points: {player.totalPoints}";
             }
             
        string highRotationsKey = "HighRotations";
        float currentHighRotations = PlayerPrefs.GetFloat(highRotationsKey, 0);
        
        if (player.totalRotations > currentHighRotations)
        {
            rotationsText.text = $"New High Rotations: {player.totalRotations}";
            PlayerPrefs.SetFloat(highRotationsKey, player.totalRotations);
            PlayerPrefs.Save(); // Don't forget to save the changes
        } else{
            
            rotationsText.text = $"Rotations: {player.totalRotations}";
        }
        
        string newTimeKey = "newTimeRecord";
        float currentTimeRecord = PlayerPrefs.GetFloat(newTimeKey, 15);
        
        if (timer.timeElapsed < currentTimeRecord)
        {
            timeText.text = $"New Time Record: {timer.timeElapsed:0.00} s";
            PlayerPrefs.SetFloat(newTimeKey, timer.timeElapsed);
            PlayerPrefs.Save(); // Don't forget to save the changes
        } else{
            timeText.text = $"Time: {timer.timeElapsed:0.00} s";
            
            Debug.Log("Time Record: " + currentTimeRecord);
        }

         }
         
         else if (currentSceneIndex == 2){
             
             string highScoreKey = "HighScore2";
             float currentHighScore = PlayerPrefs.GetFloat(highScoreKey, 0);

             if (player.totalPoints > currentHighScore)
             {
                 totalPointsText.text = $"NEW HIGH SCORE\nPoints: {player.totalPoints}";
                 PlayerPrefs.SetFloat(highScoreKey, player.totalPoints);
                 PlayerPrefs.Save(); // Don't forget to save the changes
             } else{
            
                 totalPointsText.text = $"Points: {player.totalPoints}";
             }
             
             string highRotationsKey = "HighRotations2";
             float currentHighRotations = PlayerPrefs.GetFloat(highRotationsKey, 0);
        
             if (player.totalRotations > currentHighRotations)
             {
                 rotationsText.text = $"New High Rotations: {player.totalRotations}";
                 PlayerPrefs.SetFloat(highRotationsKey, player.totalRotations);
                 PlayerPrefs.Save(); // Don't forget to save the changes
             } else{
            
                 rotationsText.text = $"Rotations: {player.totalRotations}";
             }
        
             string newTimeKey = "newTimeRecord2";
             float currentTimeRecord = PlayerPrefs.GetFloat(newTimeKey, 15);
        
             if (timer.timeElapsed < currentTimeRecord)
             {
                 timeText.text = $"New Time Record: {timer.timeElapsed:0.00} s";
                 PlayerPrefs.SetFloat(newTimeKey, timer.timeElapsed);
                 PlayerPrefs.Save(); // Don't forget to save the changes
             } else{
                 timeText.text = $"Time: {timer.timeElapsed:0.00} s";
            
                 Debug.Log("Time Record: " + currentTimeRecord);
             }

         }
         else if (currentSceneIndex == 3){
             
             string highScoreKey = "HighScore3";
             float currentHighScore = PlayerPrefs.GetFloat(highScoreKey, 0);

             if (player.totalPoints > currentHighScore)
             {
                 totalPointsText.text = $"NEW HIGH SCORE\nPoints: {player.totalPoints}";
                 PlayerPrefs.SetFloat(highScoreKey, player.totalPoints);
                 PlayerPrefs.Save(); // Don't forget to save the changes
             } else{
            
                 totalPointsText.text = $"Points: {player.totalPoints}";
             }
             
             string highRotationsKey = "HighRotations3";
             float currentHighRotations = PlayerPrefs.GetFloat(highRotationsKey, 0);
        
             if (player.totalRotations > currentHighRotations)
             {
                 rotationsText.text = $"New High Rotations: {player.totalRotations}";
                 PlayerPrefs.SetFloat(highRotationsKey, player.totalRotations);
                 PlayerPrefs.Save(); // Don't forget to save the changes
             } else{
            
                 rotationsText.text = $"Rotations: {player.totalRotations}";
             }
        
             string newTimeKey = "newTimeRecord3";
             float currentTimeRecord = PlayerPrefs.GetFloat(newTimeKey, 15);
        
             if (timer.timeElapsed < currentTimeRecord)
             {
                 timeText.text = $"New Time Record: {timer.timeElapsed:0.00} s";
                 PlayerPrefs.SetFloat(newTimeKey, timer.timeElapsed);
                 PlayerPrefs.Save(); // Don't forget to save the changes
             } else{
                 timeText.text = $"Time: {timer.timeElapsed:0.00} s";
            
                 Debug.Log("Time Record: " + currentTimeRecord);
             }

         }

         airTimeText.text = $"Total Air Time: {player.totalAirTime:0.00} s";
         maxVelocityText.text = $"Max Velocity: {player.GetMaxVelocity()} m/s";
         
         string coinsKey = "coinsCountKey";
         float currentCoinsCount = PlayerPrefs.GetFloat(coinsKey, 0);
         
         if (player.coinCount > 0){
         
         
         PlayerPrefs.SetFloat(coinsKey, (currentCoinsCount + player.coinCount));
         PlayerPrefs.Save(); // Don't forget to save the changes
         
         }
         totalCoinsCountText.text =  $"Total Coins: {PlayerPrefs.GetFloat(coinsKey, 0)}";
    }
}

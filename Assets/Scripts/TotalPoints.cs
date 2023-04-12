using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TotalPoints : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI totalPointsText;

    // Update is called once per frame
    void Update()
    {
        totalPointsText.text = $"Points: {player.totalPoints}";
    }    
        
   

}

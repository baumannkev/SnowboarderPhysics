using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI coinsText;
    
    // Update is called once per frame
    void Update()
    {
        coinsText.text = $"Coins: {player.coinCount}";
    }
}

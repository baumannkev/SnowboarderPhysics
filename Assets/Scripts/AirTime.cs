using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AirTime : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI airTimeText;
    public float airTimeMultiplier = 1.0f;

    private float airTimeCounter;
    private bool isDisplaying;

    void Update()
    {
        if (!player.isGrounded)
        {
            airTimeCounter += Time.deltaTime;
            player.airTimePoints = airTimeCounter * airTimeMultiplier;
            player.totalAirTime += Time.deltaTime;
            isDisplaying = true;
        }
        else if (isDisplaying)
        {
            isDisplaying = false;
            airTimeCounter = 0;
        }

        airTimeText.gameObject.SetActive(isDisplaying);
        airTimeText.text = $"Air Time Points: {player.airTimePoints:0.00}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Velocity : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;
    public TextMeshProUGUI velocityText;
    public TextMeshProUGUI speedText;
    

    private void Update()
    {
        Vector2 playerVelocity = playerController.GetPlayerVelocity();
        velocityText.text = $"{playerVelocity} m/s";
        
        float playerSpeed = playerController.GetPlayerSpeed();
        speedText.text = $"{playerSpeed} m/s";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotationVisualizer : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI rotationText;
    

    private void Update()
    {
        bool shouldDisplay = !player.isGrounded && player.totalRotationsInAir > 0;
        rotationText.gameObject.SetActive(shouldDisplay);
        rotationText.text = $"{player.totalRotationsInAir}";
    }
}

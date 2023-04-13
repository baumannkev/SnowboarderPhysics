using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public PlayerController player;
    public Timer timer;
    [SerializeField] private float loadDelay = 1f;
    [SerializeField] private ParticleSystem finishLineEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            timer.Finish();

            finishLineEffect.Play();
            GetComponent<AudioSource>().Play();
            
            // Stop the player
            player.baseSpeed = Mathf.Lerp(player.baseSpeed, 1, 5.0f);
            
        }
    }
    

}

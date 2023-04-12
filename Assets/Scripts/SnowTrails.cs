using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrails : MonoBehaviour
{
    [SerializeField] private ParticleSystem snowEffect;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            snowEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            snowEffect.Stop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

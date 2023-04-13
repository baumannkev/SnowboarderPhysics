using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopUp : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    

    private void Start()
    {
        settingsPanel.SetActive(!settingsPanel);
        // Initialize the slider with the current volume
        volumeSlider.value = AudioListener.volume;
        
    }
    
    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    

}

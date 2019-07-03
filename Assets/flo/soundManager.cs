using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    public AudioManager.AudioChannel channel1;
    public Text soundlevelsText;
    public string channelName = "Master Sound";

    public Slider slider;

    public void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateSoundLevel()
    {
        int sliderValue = (int)(slider.value * 100);
        
        AudioManager.Instance.SetVolume(channel1, sliderValue);

        soundlevelsText.text = channelName + ": " + sliderValue + " / " + "100";
    }
}

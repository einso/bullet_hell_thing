using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoMusic : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        audioSource.pitch = Time.timeScale;
    }
}

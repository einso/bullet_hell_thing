using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] playerDamage;
    public AudioClip[] playerDeath;
    public AudioClip[] playerNuke;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void PlayDamageSound()
    {
        int ran = Random.Range(0, 3);
        audio.clip = playerDamage[ran];
        audio.Play();
    }

    public void PlayDeathSound()
    {
        int ran = Random.Range(0, 2);
        audio.clip = playerDeath[ran];
        audio.Play();
    }

    public void PlayNukeSound()
    {
        int ran = Random.Range(0, 2);
        audio.clip = playerDeath[ran];
        audio.Play();
    }
}

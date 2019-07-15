using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SATriggerSpieler : MonoBehaviour
{
    public AudioSource SXFSpeaker;
    public AudioClip trefersound;
    public AnimationClip treffer;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            SXFSpeaker.PlayOneShot(trefersound, 0.7f);

            animator.Play("cubetreffer");
        }

    }
}

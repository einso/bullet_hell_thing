using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerLife : MonoBehaviour
{
    public GameObject lifeBarPar; //Players Life Bar Parent
    public GameObject lifeBar; //Players Life Bar

    float blinkSpeed = 0.1f;   //BlinkSpeed
    float amountOfBlinks = 5;
    bool invincible;
    public int health = 5;  //Health
    bool SetLifebarPos;
    [Space(10)]
    [Header("Camerashake On-Hit Settings")]
    public float magnitude = 0.15f;
    public float roughness = 0.15f;
    public float fadeInTime = 0.15f;
    public float fadeOutTime = 0.15f;

    //update
    void Update()
    {
        if(gameObject != null)
        {

            if (SetLifebarPos)
            {
                lifeBarPar.transform.position = new Vector3(transform.position.x - 1.2f, transform.position.y, transform.position.z);
            }

        }

    }

    //Player Collision
    void OnTriggerEnter(Collider other)
    {
        //Check if player is invincible
        if(!invincible)
        {
            //Collision with Enemy Bullet
            if (other.gameObject.tag == "EnemyBullet")
            {
                TakeDamage(other.GetComponent<EnemyBullet>().damage);  //Damage Calculation
                other.gameObject.SetActive(false); //Destroy Enemy Bullet
                CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
            }

            //Collision with Enemy
            if (other.gameObject.tag == "Enemy")
            {
                TakeDamage(1);  //Damage Calculation
                CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
            }
        }

        //Check if health is 0
        if(health <= 0)
        {
            //Destroy(gameObject);    //Destroy Player
            gameObject.SetActive(false);
            lifeBarPar.SetActive(false); //Delete Lifebar
            FindObjectOfType<Manager>().PlayerDeath();  //Game Over Screen
        }
    }

    //Damage Calculation
    void TakeDamage(int damage)
    {
        health -= damage;   //Health - Damage
        lifeBarPar.SetActive(true); //Set Lifebar Active
        SetLifebarPos = true;   //Set bool true to position the lifebar in update        
        lifeBar.transform.localScale = new Vector3(lifeBar.transform.localScale.x - 0.02f*damage, lifeBar.transform.localScale.y, lifeBar.transform.localScale.z); //Shrink life bar on hit
        lifeBar.transform.localPosition = new Vector3(lifeBar.transform.localPosition.x, lifeBar.transform.localPosition.y, lifeBar.transform.localPosition.z - 0.116f*damage); //Position Correction lifebar
        StartCoroutine(toggleInvincibility()); //Toggle invincibility if hit
        //StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.6f, 0.5f)); //Camera Shake
    }

    //Blink Player after taking Damage
    IEnumerator blinkPlayer()
    {
        for (int i = 0; i < amountOfBlinks; i++)
        {
            if(GetComponent<SpriteRenderer>().enabled == true)
            {                
                yield return new WaitForSeconds(blinkSpeed);
                GetComponent<SpriteRenderer>().enabled = false;
            }

            if(GetComponent<SpriteRenderer>().enabled == false)
            {
                yield return new WaitForSeconds(blinkSpeed);
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    //Toggle Invincibility if hit
    IEnumerator toggleInvincibility()
    {
        invincible = true;
        StartCoroutine(blinkPlayer());

        float invincibilityLength = blinkSpeed * amountOfBlinks * 2;

        yield return new WaitForSeconds(invincibilityLength);
        invincible = false;        

        yield return new WaitForSeconds(2);
        if (invincible == false)
        {
            lifeBarPar.SetActive(false); //Set Lifebar Inactive
            SetLifebarPos = false; //Set bool false to position the lifebar in update   
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    float blinkSpeed = 0.1f;   //BlinkSpeed
    float amountOfBlinks = 5;

    bool invincible;

    public int health = 5;  //Health

    //Player Collision
    void OnTriggerEnter(Collider other)
    {
        //Check if player is invincible
        if(!invincible)
        {
            //Collision with Enemy Bullet
            if (other.gameObject.tag == "EnemyBullet")
            {
                TakeDamage(1);  //Damage Calculation
                Destroy(other.gameObject); //Destroy Enemy Bullet
            }

            //Collision with Enemy
            if (other.gameObject.tag == "Enemy")
            {
                TakeDamage(1);  //Damage Calculation
            }
        }

        //Check if health is 0
        if(health <= 0)
        {
            Destroy(gameObject);    //Destroy Player
            FindObjectOfType<Manager>().PlayerDeath();  //Game Over Screen
        }
    }

    //Damage Calculation
    void TakeDamage(int damage)
    {
        health -= damage;   //Health - Damage
        StartCoroutine(toggleInvincibility()); //Toggle invincibility if hit
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public GameObject scoreFeedbackPrefab;
    public GameObject HitEnemyParticle;
    public GameObject Manager;
    public float health = 1;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            health -= 1;
        }

        if (health <= 0)
        {
            health = 100; //BugFix: when 2 bullets hit the enemy at the same time, one hit counts
            Destroy(this.gameObject);
            Manager.GetComponent<Manager>().EnemyDeathEvent(Manager, gameObject, scoreFeedbackPrefab, HitEnemyParticle);
        }
    }

    void Update()
    {
        //Screen Nuke
        if (Input.GetKeyDown(KeyCode.N))
        {
            Destroy(this.gameObject);
            Manager.GetComponent<Manager>().EnemyDeathEvent(Manager, gameObject, scoreFeedbackPrefab, HitEnemyParticle);
        }
    }
 
}

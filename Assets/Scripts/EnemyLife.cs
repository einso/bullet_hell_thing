using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public GameObject scoreFeedbackPrefab;
    public GameObject HitEnemyParticle;
    public GameObject DestroyEnemyParticle;
    public GameObject Manager;
    public float health = 1;
    bool destroy;
    float rand;
    float t;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health -= 1;
            Instantiate(HitEnemyParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }

        if (health <= 0)
        {
            health = 100; //BugFix: when 2 bullets hit the enemy at the same time, only one hit counts so that the score does not get caculated twice...
            Destroy(this.gameObject);
            Manager.GetComponent<Manager>().EnemyDeathEvent(Manager, gameObject, scoreFeedbackPrefab, HitEnemyParticle, DestroyEnemyParticle);
        }
    }

    void Update()
    {
        //Screen Nuke
        if (Input.GetKeyDown(KeyCode.N))
        {
            destroy = true;
            rand = Random.Range(0.0f, 0.5f);
            Debug.Log(rand);
        }

        if (destroy)
        {
            t += 1 * Time.deltaTime;

            if (t > rand)
            {
                Destroy(this.gameObject);
                Manager.GetComponent<Manager>().EnemyDeathEvent(Manager, gameObject, scoreFeedbackPrefab, HitEnemyParticle, DestroyEnemyParticle);
            }
        }
    }

}

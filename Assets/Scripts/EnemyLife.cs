using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    Color32 color;
    SpriteRenderer spriteRenderer;
    public GameObject EnemyProjectilePrefab;
    public GameObject scoreFeedbackPrefab;
    public GameObject HitEnemyParticle;
    public GameObject DestroyEnemyParticle;
    GameObject Manager;
    public float health = 1;
    bool destroy;
    float rand;
    float t;
    float manaCostNuke = 0.5f;
    public float giveMana = 30;

    void Awake()
    {
        //Get Manager
        Manager = GameObject.Find("Manager");

        //Get Child SpriteRender
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //get Color
        color = spriteRenderer.color;
    }


    //ON TRIGGER ENTER
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health -= 1;
            Instantiate(HitEnemyParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);


            StartCoroutine(HitVFX());
        }

        CheckHealth();
    }

    void Update()
    {
        //Screen Nuke
        if(Manager.GetComponent<PlayerAbilities>().nukeEnemy)
        {
            destroy = true;
            rand = Random.Range(0.0f, 0.5f);

        }


        if (destroy)
        {
            t += 1 * Time.deltaTime;

            if (t > rand)
            {
                health = health - Manager.GetComponent<PlayerAbilities>().nukeDamage;
                CheckHealth();
                destroy = false;
                t = 0;
            }
        }
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            health = 100; //BugFix: when 2 bullets hit the enemy at the same time, only one hit counts so that the score does not get caculated twice...
            Destroy(this.gameObject);
            Manager.GetComponent<Manager>().EnemyDeathEvent(Manager, gameObject, scoreFeedbackPrefab, HitEnemyParticle, DestroyEnemyParticle);

            //Destroy            
            DestroyEnemyC();
          
        }
    }

    IEnumerator HitVFX()
    {
        spriteRenderer.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = color;
    }

    void DestroyEnemyC()
    {
        if (transform.name == "Enemy C(Clone)")
        {
            float rotX = 0;
            float rotY = 145;
            float rotZ = 0;

            for (int i = 0; i < 16; i++)
            {
                Quaternion rot = Quaternion.Euler(rotX, rotY, rotZ);
                GameObject shot = Instantiate(EnemyProjectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), rot);
                shot.GetComponent<EnemyBullet>().speed = 7;
                rotY -= 22.5f;
            }
        }
    }
}

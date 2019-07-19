using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsPlayer : MonoBehaviour
{
    public GameObject Manager;
    public GameObject scoreFeedbackPrefab;
    public float speed = 20f;
    public Rigidbody rb;
    public GameObject DestroyEnemyParticle;
    public GameObject HitEnemyParticle;
    public bool ScoreVFX;

    void Start()
    {
        //scoreFeedbackPrefab = GameObject.Find("ScoreFeedbackTMP");
       // rb.velocity = transform.right * speed;
    }

    void Update()
    {
        //Bullet Movement            
        Quaternion rot = transform.rotation;
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(speed * Time.deltaTime, 0, 0);
        pos += rot * posChange;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            //Manager.GetComponent<Manager>().EnemyDeathEvent(Manager,other.gameObject,scoreFeedbackPrefab,HitEnemyParticle,ScoreVFX);

           

        }

        if (other.gameObject.tag == "EndWall")
        {
            gameObject.SetActive(false);
            //Manager.GetComponent<Manager>().EnemyDeathEvent(Manager,other.gameObject,scoreFeedbackPrefab,HitEnemyParticle,ScoreVFX);



        }

    }

    


}

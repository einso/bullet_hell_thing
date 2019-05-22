using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsPlayer : MonoBehaviour
{
    GameObject scoreFeedbackPrefab;
    public float speed = 20f;
    public Rigidbody rb;
    public GameObject DestroyEnemyParticle;
    public GameObject HitEnemyParticle;
    public bool ScoreVFX;

    void Start()
    {
        scoreFeedbackPrefab = GameObject.Find("ScoreFeedbackTMP");
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //DESTROY BOTH OBJECTS
            Destroy(other.gameObject);
            Destroy(gameObject);

            //CALCULATE SCORE
            float scoreValue = other.GetComponent<SinusoidalMove>().scoreValue;
            FindObjectOfType<Manager>().scoreCount += scoreValue;

            //SHOW SCORE OVER ENEMY
            if(ScoreVFX)
            {
                GameObject scoreFeedback = Instantiate(scoreFeedbackPrefab, new Vector3(other.transform.position.x - 0.3f, other.transform.position.y, other.transform.position.z - 4.8f), scoreFeedbackPrefab.transform.rotation);
                scoreFeedback.GetComponent<TextMeshPro>().text = "" + other.GetComponent<SinusoidalMove>().scoreValue;
            }

            //FindObjectOfType<SpawnEnemies>().NumberOfEnemies -= 1;

            //Spawn Particle Effect
            //Instantiate(DestroyEnemyParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);
            Instantiate(HitEnemyParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);

        }

    }

    


}

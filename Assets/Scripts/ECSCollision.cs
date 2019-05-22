using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ECSCollision : MonoBehaviour
{
    GameObject scoreFeedbackPrefab;
    public GameObject DestroyEnemyParticle;
    public GameObject HitEnemyParticle;
    public bool ScoreVFX;

    void Start()
    {
        scoreFeedbackPrefab = GameObject.Find("ScoreFeedbackTMP");       
    }

    public void DestroyOnHit()
    {
        //Destroy This
        Destroy(gameObject);

        //CALCULATE SCORE
        float scoreValue = GetComponent<SinusoidalMove>().scoreValue;
        FindObjectOfType<Manager>().scoreCount += scoreValue;

        //SHOW SCORE OVER ENEMY
        if (ScoreVFX)
        {
            GameObject scoreFeedback = Instantiate(scoreFeedbackPrefab, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z - 4.8f), scoreFeedbackPrefab.transform.rotation);
            scoreFeedback.GetComponent<TextMeshPro>().text = "" + GetComponent<SinusoidalMove>().scoreValue;
        }

        //Spawn Particle Effect
        //Instantiate(DestroyEnemyParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);
        Instantiate(HitEnemyParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}

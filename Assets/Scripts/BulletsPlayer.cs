using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsPlayer : MonoBehaviour
{
    GameObject scoreFeedbackPrefab;
    public float speed = 20f;
    public Rigidbody rb;

    void Start()
    {
        scoreFeedbackPrefab = GameObject.Find("ScoreFeedbackTMP");
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.name);
            Destroy(other.gameObject);
            Destroy(gameObject);

            float scoreValue = other.GetComponent<SinusoidalMove>().scoreValue;
            FindObjectOfType<Manager>().scoreCount += scoreValue;

            GameObject scoreFeedback = Instantiate(scoreFeedbackPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 5), scoreFeedbackPrefab.transform.rotation);
            scoreFeedback.GetComponent<TextMeshPro>().text = ""+ other.GetComponent<SinusoidalMove>().scoreValue;

            //FindObjectOfType<SpawnEnemies>().NumberOfEnemies -= 1;
        }

    }


}

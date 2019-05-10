using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPlayer : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.name);
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<Manager>().scoreCount += other.GetComponent<SinusoidalMove>().scoreValue;

            //FindObjectOfType<SpawnEnemies>().NumberOfEnemies -= 1;
        }

    }


}

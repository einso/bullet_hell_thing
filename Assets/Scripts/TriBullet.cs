using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBullet : MonoBehaviour
{
    public float speed = 2f;

    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.name);
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<Manager>().PlayerDeath();
        }
        if (other.gameObject.tag == "EndWall")
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }

    }
}

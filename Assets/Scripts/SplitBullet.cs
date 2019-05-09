using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBullet : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody rb;
    public GameObject EnemyBulletPrefab;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        if (transform.position.z < 4)
        {
            Destroy(gameObject);

            float rotX = 0;
            float rotY = 145;
            float rotZ = 0;

            for (int i = 0; i < 8; i++)
            {
                Quaternion rot = Quaternion.Euler(rotX, rotY, rotZ);
                Instantiate(EnemyBulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), rot);
                rotY -= 45;
            }
        }
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
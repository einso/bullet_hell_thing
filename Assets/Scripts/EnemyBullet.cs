using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody rb;

    void Start()
    {
        //rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        //Bullet Movement            
        Quaternion rot = transform.rotation;
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(0, 0, speed * Time.deltaTime);
        pos += rot * posChange;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<Manager>().PlayerDeath();
        }
        if (other.gameObject.tag == "EndWall")
        {

            gameObject.SetActive(false);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 2f;
    public Rigidbody rb;
    public bool shouldTriggerBulletFix = false;
    public Manager manager;

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
        if (shouldTriggerBulletFix && other.gameObject.tag == "EndWall")
        {
            manager.WaveEnemyNr--;
        }

        if (other.gameObject.tag == "EndWall")
        {
            gameObject.SetActive(false);
        }

    }

}

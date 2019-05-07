using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletSpawnPos;
    public float delay = 0.25f;
    float t;

    void Start()
    {
        t = delay;
    }

    // Update is called once per frame
    void Update()
    {
        t = t + 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && t>delay)
        {
            t = 0;            
            Instantiate(bullet, bulletSpawnPos.transform.position, transform.rotation);
        }
    }
}

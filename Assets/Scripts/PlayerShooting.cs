using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletSpawnPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, bulletSpawnPos.transform.position, transform.rotation);
        }
    }
}

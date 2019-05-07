using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
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

        if (Input.GetKey(KeyCode.Space) && t > delay)
        {
            Shoot();
            t = 0;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

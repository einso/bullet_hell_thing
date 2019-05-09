using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFireSpawn;
    public GameObject EnemyProjectilePrefab;
    public GameObject EnemyProjectilePrefab2;
    public GameObject EnemyProjectilePrefab3;
    private float time = 0;
    public float firingPeriod = 1;

    public bool linearShot;
    public bool sinusShot;
    public bool sprayShot;
    public bool splitShot;

    void Update()
    {
        time += Time.deltaTime;

        if (linearShot) LinearShot();

        if (sinusShot) SinusShot();

        if (sprayShot) SprayShot();

        if (splitShot) SplitShot();

    }
    
    void LinearShot()
    {
        if (time >= firingPeriod)
        {
            Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            time = 0;
        }
    }
    
    void SinusShot()
    {
        if (time >= firingPeriod)
        {
            Instantiate(EnemyProjectilePrefab2, enemyFireSpawn.position, enemyFireSpawn.rotation);
            time = 0;
        }
    }

    void SprayShot()
    {
        if (time >= firingPeriod)
        {
            float numberOfBullets = 4;
            float posX = -1.5f;
            float rotX = 0;
            float rotY = 150;
            float rotZ = 0;

            for (int i = 0; i < numberOfBullets; i++)
            {
                Quaternion rot = Quaternion.Euler(rotX, rotY, rotZ);
                Instantiate(EnemyProjectilePrefab, new Vector3(enemyFireSpawn.transform.position.x - posX, enemyFireSpawn.transform.position.y, enemyFireSpawn.transform.position.z), rot);
                rotY += 20;
                posX++;
            }


            time = 0;
        }
    }

    void SplitShot()
    {
        if (time >= firingPeriod)
        {
            Instantiate(EnemyProjectilePrefab3, enemyFireSpawn.position, enemyFireSpawn.rotation);
            time = 0;
        }
    }

}

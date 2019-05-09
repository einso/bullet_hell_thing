using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFireSpawn;
    public GameObject EnemyProjectilePrefab;
    public GameObject EnemyProjectilePrefab2;
    private float time = 0;
    public float firingPeriod = 1;

    public bool linearShot;
    public bool sinusShot;

    void Update()
    {
        time += Time.deltaTime;

        if (linearShot) LinearShot();

        if (sinusShot) SinusShot();

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

    void ShotGunShot()
    {

    }
    
}

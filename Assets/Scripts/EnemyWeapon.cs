using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFireSpawn;
    public GameObject EnemyProjectilePrefab;
    private float time = 0;
    public float firingPeriod = 1;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= firingPeriod)
        {
            time = 0;

            Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
        }
    }
    // Start is called before the first frame update
    

    
}

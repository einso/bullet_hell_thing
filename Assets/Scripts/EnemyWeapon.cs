using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFireSpawn;
    Transform Player;

    public GameObject EnemyProjectilePrefab;
    public GameObject EnemyProjectilePrefab2;
    public GameObject EnemyProjectilePrefab3;
    private float time = 0;
    float yincrease;
    public float firingPeriod = 1;

    public bool linearShot;
    public bool sinusShot;
    public bool sprayShot;
    public bool splitShot;
    public bool ghostShot;
    public bool duoShot;
    public bool triShot;
    public bool flowerShot;
    public bool shotEnemyA;
    public bool shotEnemyB;
    public bool shotEnemyC;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
        time = Random.Range(0, 2);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (linearShot) LinearShot(firingPeriod);

        if (sinusShot) SinusShot(firingPeriod);

        if (sprayShot) SprayShot(firingPeriod);

        if (splitShot) SplitShot(firingPeriod);

        if (ghostShot) GhostShot(firingPeriod);

        if (duoShot) DuoShot(firingPeriod);

        if (triShot) TriShot(firingPeriod);

        if (flowerShot) FlowerShot(firingPeriod);

        if (shotEnemyA) ShotEnemyA(firingPeriod, 20);

        if (shotEnemyB) ShotEnemyB(firingPeriod, 0);

        if (shotEnemyC) ShotEnemyC(firingPeriod);
    }
    
    void LinearShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            time = 0;
        }
    }
    
    void SinusShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            Instantiate(EnemyProjectilePrefab2, enemyFireSpawn.position, enemyFireSpawn.rotation);
            time = 0;
        }
    }

    void SprayShot(float firingPeriod)
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

    void SplitShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            Instantiate(EnemyProjectilePrefab3, enemyFireSpawn.position, enemyFireSpawn.rotation);
            time = 0;
        }
    }

    void GhostShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            GameObject shot = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot.GetComponent<EnemyBullet>().speed = 5;
            shot.transform.LookAt(Player);
            time = 0;
        }
    }

    void DuoShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            GameObject shot1 = Instantiate(EnemyProjectilePrefab, new Vector3(enemyFireSpawn.transform.position.x - 1.9f, 0.8f, enemyFireSpawn.transform.position.z), enemyFireSpawn.rotation);
            GameObject shot2 = Instantiate(EnemyProjectilePrefab, new Vector3(enemyFireSpawn.transform.position.x + 1.9f, 0.8f, enemyFireSpawn.transform.position.z), enemyFireSpawn.rotation);
            shot1.GetComponent<EnemyBullet>().speed = 5;
            shot2.GetComponent<EnemyBullet>().speed = 5;
            time = 0;
        }
    }

    void TriShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            GameObject shot = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot.GetComponent<EnemyBullet>().speed = 4;
            shot.transform.LookAt(Player);

            GameObject shot2 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot2.GetComponent<EnemyBullet>().speed = 3f;
            shot2.transform.LookAt(Player);

            GameObject shot3 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot3.GetComponent<EnemyBullet>().speed = 2;
            shot3.transform.LookAt(Player);

            time = 0;  
        }
    }

    void FlowerShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            float rotX = 0;
            float rotY = 145 + yincrease;
            float rotZ = 0;

            for (int i = 0; i < 8; i++)
            {
                Quaternion rot = Quaternion.Euler(rotX, rotY, rotZ);
                Instantiate(EnemyProjectilePrefab, new Vector3(0, transform.position.y, transform.position.z), rot);
                rotY -= 45;
            }

            yincrease -= 10;
            time = 0;
        }
    }

    void ShotEnemyA(float firingPeriod, float angle)
    {
        if (time >= firingPeriod)
        {
            Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
            GameObject shot = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
            shot.GetComponent<EnemyBullet>().speed = 4;

            rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180, enemyFireSpawn.rotation.z);
            GameObject shot2 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
            shot2.GetComponent<EnemyBullet>().speed = 4;

            rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180-angle, enemyFireSpawn.rotation.z);
            GameObject shot3 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
            shot3.GetComponent<EnemyBullet>().speed = 4;

            time = 0;
        }
    }

    void ShotEnemyB(float firingPeriod, float angle)
    {
        if(transform.parent.GetComponent<SinusoidalMove>().shootingTime)
        {
            if (time >= firingPeriod)
            {

                for (int i = 0; i < 18; i++)
                {
                    Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 - angle, enemyFireSpawn.rotation.z);
                    GameObject shot = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
                    shot.GetComponent<EnemyBullet>().speed = 4;
                    angle = angle + 20;
                }

                time = 0;
            }
        }
        else
        {
            time = 0;
        }

    }

    void ShotEnemyC(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            GameObject shot = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot.GetComponent<EnemyBullet>().speed = 4;
            shot.transform.LookAt(Player);

            GameObject shot2 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot2.GetComponent<EnemyBullet>().speed = 3f;
            shot2.transform.LookAt(Player);

            time = 0;
        }
    }

}

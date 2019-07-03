using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFireSpawn;
    Transform Player;

    SinusoidalMove sinusoidalMove;

    public PoolEnemyBullets poolEnemyBullets;
    public PoolEnemyRings poolEnemyRings;

    public GameObject RingeXD;
    public GameObject EnemyProjectilePrefab;
    public GameObject EnemyProjectilePrefab2;
    public GameObject EnemyProjectilePrefab3;
    private float time = 0;
    float yincrease;
    float t = 0;
    public float firingPeriod = 1;
    int shotCount;

    float angle = 0;

    public bool linearShot;
    public bool sinusShot;
    public bool sprayShot;
    public bool splitShot;
    public bool ghostShot;
    public bool duoShot;
    public bool triShot;
    public bool flowerShot;
    public bool harasserShot;
    public bool shotEnemyA;
    public bool shotEnemyB;
    public bool shotEnemyC;
    public bool shotEnemyD;

    void Start()
    {
        sinusoidalMove = GetComponentInParent<SinusoidalMove>();
        Player = GameObject.Find("Player").transform;
        time = Random.Range(0, 2);
        //poolEnemyBullets = GameObject.Find("Manager").GetComponent<PoolEnemyBullets>();

       /* if(gameObject.transform.parent.name == "Dodger")
        {
            poolEnemyRings = GameObject.Find("Manager").GetComponent<PoolEnemyRings>();
        }*/
    }

    void Update()
    {
        time += Time.deltaTime;

        if (linearShot) LinearShot(firingPeriod, 1);

        if (sinusShot) SinusShot(firingPeriod);

        if (sprayShot) SprayShot(firingPeriod);

        if (splitShot) SplitShot(firingPeriod);

        if (ghostShot) GhostShot(firingPeriod);

        if (duoShot) DuoShot(firingPeriod);

        if (triShot) TriShot(firingPeriod);

        if (flowerShot) FlowerShot(firingPeriod);

        if (harasserShot)HarasserShot(firingPeriod, 0);

        if (shotEnemyA) ShotEnemyA(firingPeriod, 20);

        if (shotEnemyB) ShotEnemyB(firingPeriod);

        if (shotEnemyC) ShotEnemyC(firingPeriod);

        if (shotEnemyD) ShotEnemyD(firingPeriod, 0);
    }
    
    void LinearShot(float firingPeriod, int amountShots)
    {
        if (time + 0.2f >= firingPeriod)
        {
            sinusoidalMove.enabled = false;

            if (time >= firingPeriod)
            {
                if(amountShots > shotCount)
                {
                    Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
                    GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                    shot.GetComponent<EnemyBullet>().speed = 4;
                    poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);
                    shotCount++;
                }

                if (time - 0.15f >= firingPeriod)
                {
                    sinusoidalMove.enabled = true;
                    time = 0;
                    shotCount = 0;
                }    
            }

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
        if (transform.parent.GetComponent<SinusoidalMove>().shootingTime)
        {
            if (time >= firingPeriod)
            {
                Vector3 pos = transform.position;
                if (pos.x <= -3f) angle = -2;
                else if (pos.x >= 4f) angle = 2;
                Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
                GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                shot.GetComponent<EnemyBullet>().speed = 4;
                poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);

                if (pos.x <= -3f) angle = -20;
                else if (pos.x >= 4f) angle = 20;
                Quaternion rot2 = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
                GameObject shot2 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                shot2.GetComponent<EnemyBullet>().speed = 4;
                poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot2);

                if (pos.x <= -3f) angle = -38;
                else if (pos.x >= 4f) angle = 38;
                Quaternion rot3 = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
                GameObject shot3 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                shot3.GetComponent<EnemyBullet>().speed = 4;
                poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot3);

                time = 0;
            }
        }
        else
        {
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

    void HarasserShot(float firingPeriod, float angle)
    {
        if (time >= firingPeriod)
        {
            float d = 0.05f;
            for (int i = 0; i < 4; i++)
            {
                d += 0.05f;
                StartCoroutine(ShotSalvage(d));
            }

            time = 0;
            shotCount = 0;
        }      
    }

    IEnumerator ShotSalvage(float tDelay)
    {

        int nrShots = 0;
        float bPos = 0;
        float posCorrection = 0;
        yield return new WaitForSeconds(tDelay);
        for (int i = 0; i < shotCount+1; i++)
        {
            nrShots++;
            bPos = 0.2f * nrShots;
            posCorrection = 0.1f * shotCount;

            Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
            GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            shot.GetComponent<EnemyBullet>().speed = 5;    
            poolEnemyBullets.InstantiateEnemyPool(new Vector3(enemyFireSpawn.position.x + bPos - posCorrection - 0.2f, enemyFireSpawn.position.y, enemyFireSpawn.position.z), rot);


            bPos = 0.6f * nrShots;
            posCorrection = 0.3f * shotCount;
            shot.transform.LookAt(new Vector3(Player.transform.position.x + bPos - posCorrection, Player.transform.position.y, Player.transform.position.z));

            time = 0;

            
        }

        shotCount++;
        nrShots = 0;
    }

    void ShotEnemyA(float firingPeriod, float angle)
    {
        if (time >= firingPeriod)
        {
            Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
            //GameObject shot = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
            GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            shot.GetComponent<EnemyBullet>().speed = 4;
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);

            rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180, enemyFireSpawn.rotation.z);
            GameObject shot2 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            shot2.GetComponent<EnemyBullet>().speed = 4;
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);
            //GameObject shot2 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
            // shot2.GetComponent<EnemyBullet>().speed = 4;

            rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180-angle, enemyFireSpawn.rotation.z);
            GameObject shot3 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            shot3.GetComponent<EnemyBullet>().speed = 4;
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);
            // GameObject shot3 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
            // shot3.GetComponent<EnemyBullet>().speed = 4;



            time = 0;
        }
    }

    void ShotEnemyB(float firingPeriod)
    {
        if(transform.parent.GetComponent<SinusoidalMove>().shootingTime)
        {
            if (time >= firingPeriod)
            {

                /* for (int i = 0; i < 18; i++)
                 {                    
                     Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 - angle, enemyFireSpawn.rotation.z);
                     GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];                    
                     shot.GetComponent<EnemyBullet>().speed = 4;
                     poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);
                     angle = angle + 20;
                 } */

                Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);

                GameObject shot = poolEnemyRings.pooledObjects[poolEnemyRings.bulletNr];
                shot.GetComponent<EnemyBullet>().speed = 4;
                poolEnemyRings.InstantiateEnemyPool(enemyFireSpawn.position, rot);
                //shot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                angle = angle + 20;

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
            GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot.GetComponent<EnemyBullet>().speed = 4;
            shot.transform.LookAt(Player);

            GameObject shot2 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot.GetComponent<EnemyBullet>().speed = 3;
            shot.transform.LookAt(Player);

            time = 0;
        }
    }

    void ShotEnemyD(float firingPeriod, float angle)
    {
        if (transform.parent.GetComponent<SinusoidalMove>().shootingTime)
        {

            if (time >= firingPeriod)
            {

                angle = Random.Range(0, 90);

                for (int i = 0; i < 18; i++)
                {
                    Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 - angle, enemyFireSpawn.rotation.z);
                    GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                    shot.GetComponent<EnemyBullet>().speed = 4;
                    poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);
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

}

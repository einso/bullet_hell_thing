using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFireSpawn;
    Transform Player;

    SinusoidalMove sinusoidalMove;
    PoolTankBullets poolTankBullets;
    PoolHarasserBullets poolHarasserBullets;
    PoolDodgerBullets poolEnemyBullets;
    PoolEnemyRings poolEnemyRings;
    PoolNoobBullets poolNoobBullets;

    public GameObject RingeXD;
    
    public GameObject EnemyProjectilePrefab;
    public GameObject EnemyProjectilePrefab2;
    public GameObject EnemyProjectilePrefab3;
    public GameObject TankBulletPrefab;
    private float time = 0;
    float yincrease;
    float t = 0;

    [Header("All")]
    public float firingPeriod = 1;
    public float bulletSpeed = 4;
    public int bulletDamage = 1;

    [Header("Dodger & Gladiator & Tank & Harasser")]
    public float firingAngle = 2;

    [Header("Dodger")]
    public float firingAngleBetweenShots = 18;

    [Header("Harasser")]
    public float distanceBetweenBullets = 0.2f;

    [Header("Tank")]
    public int NumberOfShots = 15;
    public float TimeBetwennSalvages = 3;


    [Space(20)]
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

    int shotCount;
    bool startShooting;
    float angle = 0;

    void Start()
    {
        sinusoidalMove = GetComponentInParent<SinusoidalMove>();
        Player = GameObject.Find("Player").transform;
        time = Random.Range(0, 2);
        poolEnemyBullets = GameObject.Find("Manager").GetComponent<PoolDodgerBullets>();
        poolEnemyRings = GameObject.Find("Manager").GetComponent<PoolEnemyRings>();
        poolTankBullets = GameObject.Find("Manager").GetComponent<PoolTankBullets>();
        poolHarasserBullets = GameObject.Find("Manager").GetComponent<PoolHarasserBullets>();
        poolNoobBullets = GameObject.Find("Manager").GetComponent<PoolNoobBullets>();
    }

    void Update()
    {
        if(Player == null)
        {
            enabled = false;
        }

        if(transform.parent.GetComponent<SinusoidalMove>().movedDown)
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

            if (harasserShot) HarasserShot(firingPeriod, 0);

            if (shotEnemyA) ShotEnemyA(firingPeriod, 20);

            if (shotEnemyB) ShotEnemyB(firingPeriod);

            if (shotEnemyC) ShotEnemyC(firingPeriod);

            if (shotEnemyD) ShotEnemyD(firingPeriod, 0);
        }

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
                    shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
                    shot.GetComponent<EnemyBullet>().damage = bulletDamage;
                    poolNoobBullets.InstantiateNoobPool(enemyFireSpawn.position, rot);
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
                if (pos.x <= -3f) angle = -firingAngle;
                else if (pos.x >= 4f) angle = firingAngle;
                Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
                GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
                shot.GetComponent<EnemyBullet>().damage = bulletDamage;
                poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);

                if (pos.x <= -3f) angle = -firingAngle -firingAngleBetweenShots;
                else if (pos.x >= 4f) angle = firingAngle +firingAngleBetweenShots;
                Quaternion rot2 = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
                GameObject shot2 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                shot2.GetComponent<EnemyBullet>().speed = bulletSpeed;
                shot2.GetComponent<EnemyBullet>().damage = bulletDamage;
                poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot2);

                if (pos.x <= -3f) angle = -firingAngle -firingAngleBetweenShots*2;
                else if (pos.x >= 4f) angle = firingAngle+firingAngleBetweenShots*2;
                Quaternion rot3 = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
                GameObject shot3 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                shot3.GetComponent<EnemyBullet>().speed = bulletSpeed;
                shot3.GetComponent<EnemyBullet>().damage = bulletDamage;
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
            shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot.GetComponent<EnemyBullet>().damage = bulletDamage;
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
            shot1.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot1.GetComponent<EnemyBullet>().damage = bulletDamage;
            shot2.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot2.GetComponent<EnemyBullet>().damage = bulletDamage;
            time = 0;
        }
    }

    void TriShot(float firingPeriod)
    {
        if (time >= firingPeriod)
        {
            GameObject shot = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot.GetComponent<EnemyBullet>().damage = bulletDamage;
            shot.transform.LookAt(Player);

            GameObject shot2 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot2.GetComponent<EnemyBullet>().speed = bulletSpeed - 1;
            shot2.GetComponent<EnemyBullet>().damage = bulletDamage;
            shot2.transform.LookAt(Player);

            GameObject shot3 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot3.GetComponent<EnemyBullet>().speed = bulletSpeed - 2;
            shot3.GetComponent<EnemyBullet>().damage = bulletDamage;
            shot3.transform.LookAt(Player);

            time = 0;  
        }
    }

    void FlowerShot(float firingPeriod)
    {
        if(time >= firingPeriod)
        {
            startShooting = true;
            sinusoidalMove.enabled = false;
        }

        if(startShooting)
        {
            if (time >= TimeBetwennSalvages)
            {
                float rotX = 0;
                float rotY = 145 + yincrease;
                float rotZ = 0;

                for (int i = 0; i < 8; i++)
                {
                    //StartCoroutine(FlowerSalvage(0.1f, rotX, rotY, rotZ));

                    Quaternion rot = Quaternion.Euler(rotX, rotY, rotZ);
                    GameObject shot = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
                    shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
                    shot.GetComponent<EnemyBullet>().damage = bulletDamage;
                    poolTankBullets.InstantiateTankPool(enemyFireSpawn.position, rot);
                    rotY -= 45;

                }

                shotCount++;
                yincrease -= firingAngle;
                time = 0;
            }

            if(shotCount > NumberOfShots)
            {
                startShooting = false;
                sinusoidalMove.enabled = true;
                shotCount = 0;
            }
        }


        
    }

    IEnumerator FlowerSalvage()
    {

        yield return new WaitForSeconds(0.25f);
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
            bPos = distanceBetweenBullets * nrShots;
            posCorrection = distanceBetweenBullets/2 * shotCount;

            Quaternion rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180 + angle, enemyFireSpawn.rotation.z);
            GameObject shot = poolHarasserBullets.pooledObjects[poolHarasserBullets.bulletNr];
            shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot.GetComponent<EnemyBullet>().damage = bulletDamage;
            poolHarasserBullets.InstantiateEnemyPool(new Vector3(enemyFireSpawn.position.x + bPos - posCorrection + 0.5f, enemyFireSpawn.position.y, enemyFireSpawn.position.z), rot);


            bPos = firingAngle * nrShots;
            posCorrection = firingAngle/2 * shotCount;
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
            shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot.GetComponent<EnemyBullet>().damage = bulletDamage;
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);

            rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180, enemyFireSpawn.rotation.z);
            GameObject shot2 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            shot2.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot2.GetComponent<EnemyBullet>().damage = bulletDamage;
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, rot);
            //GameObject shot2 = Instantiate(EnemyProjectilePrefab, enemyFireSpawn.position, rot);
            // shot2.GetComponent<EnemyBullet>().speed = 4;

            rot = Quaternion.Euler(enemyFireSpawn.rotation.x, -180-angle, enemyFireSpawn.rotation.z);
            GameObject shot3 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            shot3.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot3.GetComponent<EnemyBullet>().damage = bulletDamage;
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
                shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
                shot.GetComponent<EnemyBullet>().damage = bulletDamage;
                poolEnemyRings.InstantiateEnemyPool(enemyFireSpawn.position, rot);
                //shot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                angle = angle + firingAngle;

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
            shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot.GetComponent<EnemyBullet>().damage = bulletDamage;
            shot.transform.LookAt(Player);

            GameObject shot2 = poolEnemyBullets.pooledObjects[poolEnemyBullets.bulletNr];
            poolEnemyBullets.InstantiateEnemyPool(enemyFireSpawn.position, enemyFireSpawn.rotation);
            shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
            shot.GetComponent<EnemyBullet>().damage = bulletDamage;
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
                    shot.GetComponent<EnemyBullet>().speed = bulletSpeed;
                    shot.GetComponent<EnemyBullet>().damage = bulletDamage;
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

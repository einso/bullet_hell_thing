using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool Baseshot;
    public bool Playerlevel1;
    public bool Playerlevel2;
    public bool Playerlevel3;
    public bool Playerlevel4;
    bool Playerlevel5;
    [Space(20)]
    public float delay = 0.15f;
    public float baseShotDistanceBetweenShots = 0.5f;
    public float podSprayStrength = 7;
    float shiftPodSprayStrength = 0;
    float weapon3SprayStrength = 7;
    float weapon4SprayStrength = 7;
    float weapon5SprayStrength = 7;
    [Space(20)]
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject piercingBulletPrefab;
    public GameObject bulletPrefab;
    public Transform pod;
    public GameObject podLeft;
    public GameObject podRight;
    Vector3 podLeftTran;
    Vector3 podRightTran;
    float podDistanceToPlayer;
    float t;

    Quaternion bulletRotation1;
    Quaternion bulletRotation2;
    Quaternion bulletRotation3;
    Quaternion bulletRotation4;

    void Start()
    {
        t = delay;
        podDistanceToPlayer = podRight.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        t = t + 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && t > delay)
        {
            if(Baseshot)
            {
                BaseShot();
                t = 0;
            }
            else if(Playerlevel1)
            {
                
                PlayerLevel1();
                t = 0;
            }
            else if(Playerlevel2)
            {
                PlayerLevel2();
                t = 0;
            }
            else if(Playerlevel3)
            {
                PlayerLevel3();
                t = 0;
            }
            else if (Playerlevel4)
            {
                PlayerLevel4();
                t = 0;
            }
            else if (Playerlevel5)
            {
                PlayerWeapon5();
                t = 0;
            }

        }
    }

    //BaseShot
    void BaseShot()
    {
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);

        float distance = baseShotDistanceBetweenShots / 2;
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - distance, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + distance, firePoint.position.y, firePoint.position.z), bulletRotation2);
    }

    //Player Level 1
    void PlayerLevel1()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - distance, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + distance, firePoint.position.y, firePoint.position.z), bulletRotation2);

        //PodShot
        Instantiate(piercingBulletPrefab, pod.position, bulletRotation1);
    }

    //Player Level 2
    void PlayerLevel2()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - distance, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + distance, firePoint.position.y, firePoint.position.z), bulletRotation2);

        //PodShot
        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - shiftPodSprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + shiftPodSprayStrength, 0);
        }
        else
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - podSprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + podSprayStrength, 0);
        }
        
        Instantiate(piercingBulletPrefab, new Vector3(pod.position.x -0.2f, pod.position.y, pod.position.z), bulletRotation1);
        Instantiate(piercingBulletPrefab, new Vector3(pod.position.x + 0.2f, pod.position.y, pod.position.z), bulletRotation2);
    }

    //Player Level 3
    void PlayerLevel3()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - distance, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + distance, firePoint.position.y, firePoint.position.z), bulletRotation2);

        //PodShot
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float shiftPodLeft = firePoint.position.x - baseShotDistanceBetweenShots *2;
            float shiftPodRight = firePoint.position.x + baseShotDistanceBetweenShots *2 ;
            podLeft.transform.position = new Vector3(shiftPodLeft, podLeft.transform.position.y, podLeft.transform.position.z);
            podRight.transform.position = new Vector3(shiftPodRight, podLeft.transform.position.y, podLeft.transform.position.z);
        }
        else
        {
            podLeft.transform.position = new Vector3(firePoint.position.x - podDistanceToPlayer, podLeft.transform.position.y, podLeft.transform.position.z);
            podRight.transform.position = new Vector3(firePoint.position.x + podDistanceToPlayer, podLeft.transform.position.y, podLeft.transform.position.z);
        }

        Instantiate(piercingBulletPrefab, new Vector3(podLeft.transform.position.x, podLeft.transform.position.y, podLeft.transform.position.z), bulletRotation1);
        Instantiate(piercingBulletPrefab, new Vector3(podRight.transform.position.x, podRight.transform.position.y, podRight.transform.position.z), bulletRotation2);
    }

    //Player Level 4
    void PlayerLevel4()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - distance, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + distance, firePoint.position.y, firePoint.position.z), bulletRotation1);

        //PodShot
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float shiftPodLeft = firePoint.position.x - baseShotDistanceBetweenShots * 2;
            float shiftPodRight = firePoint.position.x + baseShotDistanceBetweenShots * 2;
            podLeft.transform.position = new Vector3(shiftPodLeft, podLeft.transform.position.y, podLeft.transform.position.z);
            podRight.transform.position = new Vector3(shiftPodRight, podLeft.transform.position.y, podLeft.transform.position.z);
            bulletRotation2 = bulletRotation1;
            bulletRotation3 = bulletRotation1;
        }
        else
        {
            podLeft.transform.position = new Vector3(firePoint.position.x - podDistanceToPlayer, podLeft.transform.position.y, podLeft.transform.position.z);
            podRight.transform.position = new Vector3(firePoint.position.x + podDistanceToPlayer, podLeft.transform.position.y, podLeft.transform.position.z);
            bulletRotation2 = Quaternion.Euler(0, -90 + podSprayStrength, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - podSprayStrength, 0);
        }

        Instantiate(piercingBulletPrefab, new Vector3(podLeft.transform.position.x, podLeft.transform.position.y, podLeft.transform.position.z), bulletRotation1);
        Instantiate(piercingBulletPrefab, new Vector3(podLeft.transform.position.x - baseShotDistanceBetweenShots, podLeft.transform.position.y, podLeft.transform.position.z), bulletRotation3);
        Instantiate(piercingBulletPrefab, new Vector3(podRight.transform.position.x, podRight.transform.position.y, podRight.transform.position.z), bulletRotation1);
        Instantiate(piercingBulletPrefab, new Vector3(podRight.transform.position.x + baseShotDistanceBetweenShots, podRight.transform.position.y, podRight.transform.position.z), bulletRotation2);
    }

    //Player Level 5
    void PlayerWeapon5()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - shiftPodSprayStrength, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - shiftPodSprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + shiftPodSprayStrength, 0);
            bulletRotation4 = Quaternion.Euler(0, -90 + shiftPodSprayStrength, 0);
        }
        else
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weapon5SprayStrength, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - weapon5SprayStrength - weapon5SprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weapon5SprayStrength, 0);
            bulletRotation4 = Quaternion.Euler(0, -90 + weapon5SprayStrength + weapon5SprayStrength, 0);
        }

        Instantiate(bulletPrefab, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z + 0.1f), firePoint.rotation);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - 0.15f, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - 0.3f, firePoint.position.y, firePoint.position.z - 0.1f), bulletRotation3);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.15f, firePoint.position.y, firePoint.position.z), bulletRotation2);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.3f, firePoint.position.y, firePoint.position.z - 0.1f), bulletRotation4);
    }
}

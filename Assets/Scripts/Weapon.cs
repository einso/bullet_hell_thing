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
    public GameObject PlayerBullets;
    public GameObject levelUPFeedback;
    Vector3 podLeftTran;
    Vector3 podRightTran;
    float podDistanceToPlayer;
    float t;

    Quaternion bulletRotation1;
    Quaternion bulletRotation2;
    Quaternion bulletRotation3;
    Quaternion bulletRotation4;

    //Pooling
    public int pooledAmount = 50;
    public List<GameObject> pooledObjects;
    int bulletNr = 0;

    public AudioSource playerShotSound;
    //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;


    void Start()
    {
        //Fetch the AudioSource from the GameObject
        playerShotSound = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        m_Play = true;

        t = delay;

        //Pooling
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject b = Instantiate(bulletPrefab);
            b.transform.parent = PlayerBullets.transform; 
            b.SetActive(false);
            pooledObjects.Add(b);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t = t + 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && t > delay)
        {            

            if(Baseshot)
            {
                if (pod.GetComponent<SpriteRenderer>().enabled == true) pod.GetComponent<SpriteRenderer>().enabled = false;
                if (podLeft.GetComponent<SpriteRenderer>().enabled == true) podLeft.GetComponent<SpriteRenderer>().enabled = false;
                if (podRight.GetComponent<SpriteRenderer>().enabled == true) podRight.GetComponent<SpriteRenderer>().enabled = false;
                BaseShot();
                t = 0;
            }
            else if(Playerlevel1)
            {
                if(pod.GetComponent<SpriteRenderer>().enabled == false) pod.GetComponent<SpriteRenderer>().enabled = true;
                if (podLeft.GetComponent<SpriteRenderer>().enabled == true) podLeft.GetComponent<SpriteRenderer>().enabled = false;
                if (podRight.GetComponent<SpriteRenderer>().enabled == true) podRight.GetComponent<SpriteRenderer>().enabled = false;
                PlayerLevel1();
                t = 0;
            }
            else if(Playerlevel2)
            {
                if (pod.GetComponent<SpriteRenderer>().enabled == false) pod.GetComponent<SpriteRenderer>().enabled = true;
                if (podLeft.GetComponent<SpriteRenderer>().enabled == true) podLeft.GetComponent<SpriteRenderer>().enabled = false;
                if (podRight.GetComponent<SpriteRenderer>().enabled == true) podRight.GetComponent<SpriteRenderer>().enabled = false;
                PlayerLevel2();
                t = 0;
            }
            else if(Playerlevel3)
            {
                if (pod.GetComponent<SpriteRenderer>().enabled == true) pod.GetComponent<SpriteRenderer>().enabled = false;
                if (podLeft.GetComponent<SpriteRenderer>().enabled == false) podLeft.GetComponent<SpriteRenderer>().enabled = true;
                if (podRight.GetComponent<SpriteRenderer>().enabled == false) podRight.GetComponent<SpriteRenderer>().enabled = true;
                PlayerLevel3();
                t = 0;
            }
            else if (Playerlevel4)
            {
                if (pod.GetComponent<SpriteRenderer>().enabled == true) pod.GetComponent<SpriteRenderer>().enabled = false;
                if (podLeft.GetComponent<SpriteRenderer>().enabled == false) podLeft.GetComponent<SpriteRenderer>().enabled = true;
                if (podRight.GetComponent<SpriteRenderer>().enabled == false) podRight.GetComponent<SpriteRenderer>().enabled = true;
                PlayerLevel4();
                t = 0;
            }
            else if (Playerlevel5)
            {
                PlayerWeapon5();
                t = 0;
            }

        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            transform.parent.GetComponent<Animator>().enabled = true;
            
        }

        else
        {
            transform.parent.GetComponent<Animator>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        { playerShotSound.Play(); }
        if (Input.GetKeyUp(KeyCode.Space))
        { playerShotSound.Stop(); }

    }

    //BaseShot
    void BaseShot()
    {
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);

        float distance = baseShotDistanceBetweenShots / 2;

        InstantiatePool(new Vector3(firePoint.position.x - distance, firePoint.position.y - 0.1f, firePoint.position.z), bulletRotation1);
        InstantiatePool(new Vector3(firePoint.position.x + distance, firePoint.position.y - 0.1f, firePoint.position.z), bulletRotation2);
    }

    //Player Level 1
    void PlayerLevel1()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        InstantiatePool(new Vector3(firePoint.position.x - distance, firePoint.position.y - 0.1f, firePoint.position.z), bulletRotation1);
        InstantiatePool(new Vector3(firePoint.position.x + distance, firePoint.position.y - 0.1f, firePoint.position.z), bulletRotation2);

        //PodShot
        InstantiatePool(new Vector3(pod.position.x, pod.position.y - 0.1f, pod.position.z), bulletRotation1);
    }

    //Player Level 2
    void PlayerLevel2()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        InstantiatePool(new Vector3(firePoint.position.x - distance, firePoint.position.y - 0.1f, firePoint.position.z), bulletRotation1);
        InstantiatePool(new Vector3(firePoint.position.x + distance, firePoint.position.y - 0.1f, firePoint.position.z), bulletRotation2);

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
        
        InstantiatePool(new Vector3(pod.position.x -0.2f, pod.position.y - 0.1f, pod.position.z), bulletRotation1);
        InstantiatePool(new Vector3(pod.position.x + 0.2f, pod.position.y - 0.1f, pod.position.z), bulletRotation2);
    }

    //Player Level 3
    void PlayerLevel3()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        bulletRotation2 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        InstantiatePool(new Vector3(firePoint.position.x - distance, firePoint.position.y , firePoint.position.z), bulletRotation1);
        InstantiatePool(new Vector3(firePoint.position.x + distance, firePoint.position.y , firePoint.position.z), bulletRotation2);

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
            podLeft.transform.position = new Vector3(firePoint.position.x - 1, podLeft.transform.position.y, podLeft.transform.position.z);
            podRight.transform.position = new Vector3(firePoint.position.x + 1, podLeft.transform.position.y, podLeft.transform.position.z);
        }

        InstantiatePool(new Vector3(podLeft.transform.position.x, podLeft.transform.position.y-0.1f, podLeft.transform.position.z), bulletRotation1);
        InstantiatePool(new Vector3(podRight.transform.position.x, podRight.transform.position.y-0.1f, podRight.transform.position.z), bulletRotation2);
    }

    //Player Level 4
    void PlayerLevel4()
    {
        //BaseShot
        bulletRotation1 = Quaternion.Euler(0, -90, 0);
        float distance = baseShotDistanceBetweenShots / 2;
        InstantiatePool( new Vector3(firePoint.position.x - distance, firePoint.position.y-0.1f , firePoint.position.z), bulletRotation1);
        InstantiatePool( new Vector3(firePoint.position.x + distance, firePoint.position.y-0.1f , firePoint.position.z), bulletRotation1);

        //PodShot
        if (Input.GetKey(KeyCode.LeftShift))
        {
            distance = 0;
            float shiftPodLeft = firePoint.position.x - baseShotDistanceBetweenShots * 2;
            float shiftPodRight = firePoint.position.x + baseShotDistanceBetweenShots * 2;
            podLeft.transform.position = new Vector3(shiftPodLeft, podLeft.transform.position.y, podLeft.transform.position.z);
            podRight.transform.position = new Vector3(shiftPodRight, podLeft.transform.position.y, podLeft.transform.position.z);
            bulletRotation2 = bulletRotation1;
            bulletRotation3 = bulletRotation1;
        }
        else
        {
            podLeft.transform.position = new Vector3(firePoint.position.x - 0.35f, podLeft.transform.position.y, podLeft.transform.position.z);
            podRight.transform.position = new Vector3(firePoint.position.x + 0.35f, podLeft.transform.position.y, podLeft.transform.position.z);
            bulletRotation2 = Quaternion.Euler(0, -90 + podSprayStrength, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - podSprayStrength, 0);
        }

        InstantiatePool( new Vector3(podLeft.transform.position.x + baseShotDistanceBetweenShots / 2 - distance, podLeft.transform.position.y-0.1f, podLeft.transform.position.z), bulletRotation1);
        InstantiatePool( new Vector3(podLeft.transform.position.x - baseShotDistanceBetweenShots/2, podLeft.transform.position.y - 0.1f, podLeft.transform.position.z), bulletRotation3);
        InstantiatePool( new Vector3(podRight.transform.position.x - baseShotDistanceBetweenShots / 2 + distance , podRight.transform.position.y-0.1f, podRight.transform.position.z), bulletRotation1);
        InstantiatePool( new Vector3(podRight.transform.position.x + baseShotDistanceBetweenShots/2, podRight.transform.position.y - 0.1f, podRight.transform.position.z), bulletRotation2);
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

        InstantiatePool( new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z + 0.1f), firePoint.rotation);
        InstantiatePool( new Vector3(firePoint.position.x - 0.15f, firePoint.position.y-0.1f , firePoint.position.z), bulletRotation1);
        InstantiatePool( new Vector3(firePoint.position.x - 0.3f, firePoint.position.y-0.1f , firePoint.position.z - 0.1f), bulletRotation3);
        InstantiatePool( new Vector3(firePoint.position.x + 0.15f, firePoint.position.y-0.1f , firePoint.position.z), bulletRotation2);
        InstantiatePool( new Vector3(firePoint.position.x + 0.3f, firePoint.position.y-0.1f , firePoint.position.z - 0.1f), bulletRotation4);
    }

    void InstantiatePool(Vector3 pos, Quaternion rot)
    {
        pooledObjects[bulletNr].transform.position = pos;
        pooledObjects[bulletNr].transform.rotation = rot;
        pooledObjects[bulletNr].SetActive(true);
        //pooledObjects[bulletNr].GetComponent<ParticleSystem>().Play();
        bulletNr++;
        if (bulletNr > pooledAmount-1) bulletNr = 0;
       
    }
}

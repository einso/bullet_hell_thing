using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class EntityCreater : MonoBehaviour
{
    public bool Baseshot;
    public bool Playerlevel1;
    public bool Playerlevel2;
    public bool Playerlevel3;
    public bool Playerlevel4;
    [Space(20)]
    public float delay = 0.25f;
    public float baseShotDistanceBetweenShots = 0.25f;
    float weaponSprayStrengthWhilePressingShift = 0;
    public float podSprayStrength = 7;
    float weapon3SprayStrength = 7;
    float weapon4SprayStrength = 7;
    float weapon5SprayStrength = 7;
    public float bulletSpeed = 20;
    [Space(20)]


    public GameObject Player;
    public GameObject Pod;
    public GameObject PodLeft;
    public GameObject PodRight;
    float t;
    float podDistanceToPlayer;
    float shiftPodLeft;
    float shiftPodRight;
    EntityManager entityManager;
    Entity bullet;

    Quaternion bulletRotation1;
    Quaternion bulletRotation2;
    Quaternion bulletRotation3;
    Quaternion bulletRotation4;

    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;

    void Start()
    {
        entityManager = World.Active.EntityManager;
        podDistanceToPlayer = PodRight.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Time
        t = t + 1 * Time.deltaTime;

        //Create Bullet Entities
        if (Input.GetKey(KeyCode.Space) && t > delay)
        {
            if (Baseshot)
            {
                BaseShot();
                t = 0;
            }
            else if (Playerlevel1)
            {
                PlayerLevel1();
                t = 0;
            }
            else if (Playerlevel2)
            {
                PlayerLevel2();
                t = 0;
            }
            else if (Playerlevel3)
            {
                PlayerLevel3();
                t = 0;
            }
            else if (Playerlevel4)
            {
                PlayerLevel4();
                t = 0;
            }

        }

        //Player BaseShot
        void BaseShot() {
            float distance = baseShotDistanceBetweenShots / 2;
            CreateBullet(distance, 0, Player.transform.rotation);
            CreateBullet(-distance, 0, Player.transform.rotation);

            t = 0;  //reset time
        }

        //Player Level 1
        void PlayerLevel1()
        {
            float distance = baseShotDistanceBetweenShots / 2;
            CreateBullet(distance, 0, Player.transform.rotation);
            CreateBullet(-distance, 0, Player.transform.rotation);
            CreateBullet( 0, Pod.transform.position.z, Player.transform.rotation);



            t = 0; //reset time
        }

        //Player Level 2
        void PlayerLevel2()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                bulletRotation1 = Quaternion.Euler(90, 0, 0);
                bulletRotation2 = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                bulletRotation1 = Quaternion.Euler(90, 0 - podSprayStrength, 0);
                bulletRotation2 = Quaternion.Euler(90, 0 + podSprayStrength, 0);
            }

            float distance = baseShotDistanceBetweenShots / 2;
            CreateBullet(distance, 0, Player.transform.rotation);
            CreateBullet(-distance, 0, Player.transform.rotation);
            CreateBullet(-distance, Pod.transform.position.z, bulletRotation1);
            CreateBullet(distance, Pod.transform.position.z, bulletRotation2);

            t = 0; //reset time
        }

        //Player Level 3
        void PlayerLevel3()
        {
            
            float distance = baseShotDistanceBetweenShots / 2;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                shiftPodLeft = Player.transform.position.x - baseShotDistanceBetweenShots * 2;
                shiftPodRight = Player.transform.position.x + baseShotDistanceBetweenShots * 2;
                PodLeft.transform.position = new Vector3(shiftPodLeft, Player.transform.position.y, Player.transform.position.z);
                PodRight.transform.position = new Vector3(shiftPodRight, Player.transform.position.y, Player.transform.position.z);

            }
            else
            {
                shiftPodLeft = Player.transform.position.x - podDistanceToPlayer;
                shiftPodRight = Player.transform.position.x + podDistanceToPlayer;
                PodLeft.transform.position = new Vector3(shiftPodLeft, PodLeft.transform.position.y, PodLeft.transform.position.z);
                PodRight.transform.position = new Vector3(shiftPodRight, PodRight.transform.position.y, PodRight.transform.position.z);
            }

            CreateBullet(distance, 0, Player.transform.rotation);
            CreateBullet(-distance, 0, Player.transform.rotation);
            CreatePiercingBullet(PodLeft.transform.position.x, 0, Player.transform.rotation);
            CreatePiercingBullet(PodRight.transform.position.x, 0, Player.transform.rotation);

            t = 0; //reset time
        }

        //Player Level 4
        void PlayerLevel4()
        {
            float distance = baseShotDistanceBetweenShots / 2;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                bulletRotation1 = Quaternion.Euler(90, 0, 0);
                bulletRotation2 = Quaternion.Euler(90, 0, 0);
                shiftPodLeft = Player.transform.position.x - baseShotDistanceBetweenShots * 2;
                shiftPodRight = Player.transform.position.x + baseShotDistanceBetweenShots * 2;
                PodLeft.transform.position = new Vector3(shiftPodLeft, Player.transform.position.y, Player.transform.position.z);
                PodRight.transform.position = new Vector3(shiftPodRight, Player.transform.position.y, Player.transform.position.z);

            }
            else
            {
                bulletRotation1 = Quaternion.Euler(90, 0 - podSprayStrength, 0);
                bulletRotation2 = Quaternion.Euler(90, 0 + podSprayStrength, 0);
                shiftPodLeft = Player.transform.position.x - podDistanceToPlayer;
                shiftPodRight = Player.transform.position.x + podDistanceToPlayer;
                PodLeft.transform.position = new Vector3(shiftPodLeft, PodLeft.transform.position.y, PodLeft.transform.position.z);
                PodRight.transform.position = new Vector3(shiftPodRight, PodRight.transform.position.y, PodRight.transform.position.z);
            }

            CreateBullet(distance, 0, Player.transform.rotation);
            CreateBullet(-distance, 0, Player.transform.rotation);
            CreatePiercingBullet(PodLeft.transform.position.x + distance, 0, Player.transform.rotation);
            CreatePiercingBullet(PodLeft.transform.position.x - distance, 0, bulletRotation1);
            CreatePiercingBullet(PodRight.transform.position.x + distance, 0, bulletRotation2);
            CreatePiercingBullet(PodRight.transform.position.x - distance, 0, Player.transform.rotation);

            t = 0; //reset time
        }

        //Create Bullet Template
        void CreateBullet(float posX, float posZ, Quaternion rot)
        {
            bullet = entityManager.CreateEntity(typeof(BulletComponent), typeof(Translation), typeof(RenderMesh), typeof(LocalToWorld), typeof(Rotation)); //assign components
            entityManager.SetComponentData(bullet, new BulletComponent { moveSpeed = bulletSpeed }); //set movespeed of bullet
            entityManager.SetComponentData(bullet, new Translation { Value = new Vector3(Player.transform.position.x + posX, Player.transform.position.y, Player.transform.position.z + posZ) }); //set bullet position
            entityManager.SetComponentData(bullet, new Rotation { Value = rot }); //set bullet rotation
            entityManager.SetSharedComponentData(bullet, new RenderMesh { mesh = mesh, material = material }); //set mesh and material
        }

        void CreatePiercingBullet(float posX, float posZ, Quaternion rot)
        {
            bullet = entityManager.CreateEntity(typeof(BulletComponent), typeof(Translation), typeof(RenderMesh), typeof(LocalToWorld), typeof(Rotation)); //assign components
            entityManager.SetComponentData(bullet, new BulletComponent { moveSpeed = bulletSpeed }); //set movespeed of bullet
            entityManager.SetComponentData(bullet, new Translation { Value = new Vector3(posX, Player.transform.position.y, Player.transform.position.z + posZ) }); //set bullet position
            entityManager.SetComponentData(bullet, new Rotation { Value = rot }); //set bullet rotation
            entityManager.SetSharedComponentData(bullet, new RenderMesh { mesh = mesh, material = material }); //set mesh and material
        }
    }
}

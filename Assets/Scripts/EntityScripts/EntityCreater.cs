using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class EntityCreater : MonoBehaviour
{
    public bool Playerweapon1;
    public bool Playerweapon2;
    public bool Playerweapon3;
    public bool Playerweapon4;
    public bool Playerweapon5;
    [Space(20)]
    public float delay = 0.25f;
    float weaponSprayStrengthWhilePressingShift = 0;
    public float weapon2SprayStrength = 7;
    public float weapon3SprayStrength = 7;
    public float weapon4SprayStrength = 7;
    public float weapon5SprayStrength = 7;
    public float bulletSpeed = 20;
    [Space(20)]


    public GameObject Player;
    float t;
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
    }

    // Update is called once per frame
    void Update()
    {
        //Time
        t = t + 1 * Time.deltaTime;

        //Create Bullet Entities
        if (Input.GetKey(KeyCode.Space) && t > delay)
        {
            if (Playerweapon1)
            {
                PlayerWeapon1();
                t = 0;
            }
            else if (Playerweapon2)
            {
                PlayerWeapon2();
                t = 0;
            }
            else if (Playerweapon3)
            {
                PlayerWeapon3();
                t = 0;
            }
            else if (Playerweapon4)
            {
                PlayerWeapon4();
                t = 0;
            }
            else if (Playerweapon5)
            {
                PlayerWeapon5();
                t = 0;
            }

        }

        //Player Level 1
        void PlayerWeapon1() {
            CreateBullet(0, 0, Player.transform.rotation);
        }

        //Player Level 2
        void PlayerWeapon2()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                bulletRotation1 = Quaternion.Euler(90, 0, 0);
                bulletRotation2 = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                bulletRotation1 = Quaternion.Euler(90, 0 - weapon2SprayStrength, 0);
                bulletRotation2 = Quaternion.Euler(90, 0 + weapon2SprayStrength, 0);
            }

            CreateBullet(-0.2f, 0, bulletRotation1);
            CreateBullet(+0.2f, 0, bulletRotation2);

            t = 0; //reset time
        }

        //Player Level 3
        void PlayerWeapon3()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                bulletRotation1 = Quaternion.Euler(90, 0, 0);
                bulletRotation2 = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                bulletRotation1 = Quaternion.Euler(90, 0 - weapon3SprayStrength, 0);
                bulletRotation2 = Quaternion.Euler(90, 0 + weapon3SprayStrength, 0);
            }

            CreateBullet(0, 0, Player.transform.rotation);
            CreateBullet(-0.2f, 0, bulletRotation1);
            CreateBullet(+0.2f, 0, bulletRotation2);

            t = 0; //reset time
        }

        //Player Level 4
        void PlayerWeapon4()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                bulletRotation1 = Quaternion.Euler(90, 0, 0);
                bulletRotation3 = Quaternion.Euler(90, 0, 0);
                bulletRotation2 = Quaternion.Euler(90, 0, 0);
                bulletRotation4 = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                bulletRotation1 = Quaternion.Euler(90, 0 - weapon3SprayStrength, 0);
                bulletRotation3 = Quaternion.Euler(90, 0 - weapon3SprayStrength - weapon3SprayStrength - weapon3SprayStrength, 0);
                bulletRotation2 = Quaternion.Euler(90, 0 + weapon3SprayStrength, 0);
                bulletRotation4 = Quaternion.Euler(90, 0 + weapon3SprayStrength + weapon3SprayStrength + weapon3SprayStrength, 0);
            }

            CreateBullet(-0.1f, 0, bulletRotation1);
            CreateBullet(-0.3f, -0.1f, bulletRotation3);
            CreateBullet(+0.1f, 0, bulletRotation2);
            CreateBullet(+0.3f, -0.1f, bulletRotation4);

            t = 0; //reset time
        }

        //Player Level 5
        void PlayerWeapon5()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                bulletRotation1 = Quaternion.Euler(90, 0, 0);
                bulletRotation3 = Quaternion.Euler(90, 0, 0);
                bulletRotation2 = Quaternion.Euler(90, 0, 0);
                bulletRotation4 = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                bulletRotation1 = Quaternion.Euler(90, 0 - weapon3SprayStrength, 0);
                bulletRotation3 = Quaternion.Euler(90, 0 - weapon3SprayStrength - weapon3SprayStrength , 0);
                bulletRotation2 = Quaternion.Euler(90, 0 + weapon3SprayStrength, 0);
                bulletRotation4 = Quaternion.Euler(90, 0 + weapon3SprayStrength + weapon3SprayStrength , 0);
            }

            CreateBullet(0, +0.1f, Player.transform.rotation);
            CreateBullet(-0.15f, 0,bulletRotation1);
            CreateBullet(-0.3f, -0.1f,bulletRotation3);
            CreateBullet(+0.15f, 0,bulletRotation2);
            CreateBullet(+0.3f, -0.1f,bulletRotation4);

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
    }
}

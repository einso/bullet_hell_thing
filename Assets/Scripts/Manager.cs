using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class Manager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;


    EntityManager entityManager;
    Entity bullet;

    public float bulletSpeed = 2;

    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;

    void Start()
    {
        entityManager = World.Active.EntityManager;
    }

    // Update is called once per frame
    void Update()
    {
        //Create Bullet Entities
        if (Input.GetKey(KeyCode.Space))
        {
            bullet = entityManager.CreateEntity(typeof(BulletComponent), typeof(Translation), typeof(RenderMesh), typeof(LocalToWorld), typeof(Rotation), typeof(EnemyPosComponent));
            entityManager.SetComponentData(bullet, new BulletComponent { moveSpeed = bulletSpeed });
            entityManager.SetComponentData(bullet, new Translation { Value = Player.transform.position });
            entityManager.SetComponentData(bullet, new Rotation { Value = Player.transform.rotation });
            entityManager.SetSharedComponentData(bullet, new RenderMesh { mesh = mesh, material = material });

            Vector3 enemyPos = Enemy.transform.position;
            entityManager.SetComponentData(bullet, new EnemyPosComponent { enemyPos = Enemy.transform.position });
        }




    }
}

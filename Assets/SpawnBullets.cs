using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class SpawnBullets : MonoBehaviour
{
    public float bulletSpeed = 2; 
    public float playerMoveSpeed = 15;
    public float playerRotationSpeed = 15;

    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;

    EntityManager entityManager;

    private void Start()
    {
        entityManager = World.Active.EntityManager;
    }

    private void Update()
    {

        //Rotate Player
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Rotation") * playerRotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(90, 0, 0);
        transform.rotation = rot;

        //Move Player
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime, 0);
        pos += rot * posChange;
        transform.position = pos;

        //Create Bullet Entities
        if (Input.GetKey(KeyCode.Space))
        {
            Entity bullet = entityManager.CreateEntity(typeof(BulletComponent), typeof(Translation), typeof(RenderMesh), typeof(LocalToWorld), typeof(Rotation));
            entityManager.SetComponentData(bullet, new BulletComponent { moveSpeed = bulletSpeed });
            entityManager.SetComponentData(bullet, new Translation { Value = transform.position });
            entityManager.SetComponentData(bullet, new Rotation { Value = transform.rotation });
            entityManager.SetSharedComponentData(bullet, new RenderMesh { mesh = mesh, material = material });
        }

    }
}

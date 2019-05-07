using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class HybridTest : MonoBehaviour
{
    public Vector3 pos;
}

class HybridTestSystem : ComponentSystem
{
    struct Components
    {
        public Transform transform;
       
    }

    protected override void OnUpdate()
    {
        //Do something for each Entity with referenced components
        Entities.ForEach(( ref BulletComponent bulletComponent, ref EnemyPosComponent enemyPosComponent) =>
        {

            


            

        });
    }
}
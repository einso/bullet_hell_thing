using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


class HybridTestSystem : ComponentSystem
{
    struct Componentstest
    {
        public Transform transform;
       
    }

    protected override void OnUpdate()
    {
        //Do something for each Entity with referenced components
        Entities.ForEach(( ref BulletComponent bulletComponent) =>
        {


            



        });
    }
}
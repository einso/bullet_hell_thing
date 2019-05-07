using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Physics;

public class BulletSystem : ComponentSystem 
{
    //Update
    protected override void OnUpdate()
    {



        //Do something for each Entity with referenced components
        Entities.ForEach((ref Translation translation, ref BulletComponent bulletComponent, ref Rotation rotation, ref EnemyPosComponent enemyPosComponent) =>
        {

            //Bullet Movement            
            Quaternion rot = rotation.Value;
            float angleZ = rot.eulerAngles.z; 
            Vector3 pos = translation.Value;
            Vector3 posChange = new Vector3(0, bulletComponent.moveSpeed * Time.deltaTime, 0);
            pos += rot * posChange;
            translation.Value = pos;

            Vector3 enemyPos = enemyPosComponent.enemyPos;

            if( enemyPos.x - 0.55f < translation.Value.x &&
                enemyPos.x + 0.55f > translation.Value.x &&
                enemyPos.y + 0.25f > translation.Value.y &&
                enemyPos.y - 0.25f < translation.Value.y)
            {
                
                GameObject Enemy = GameObject.Find("Enemy 1");
                Enemy.GetComponent<EnemyLife>().health = 0;                
            }
            

           /* //Bulet Physics
            if (translation.Value.y > 5)
            {
                rot = Quaternion.Euler(0, 0,  180 - angleZ);               
                rotation.Value = rot;
            }

            else if (translation.Value.y < -5)
            {
                rot = Quaternion.Euler(0, 0, 180 - angleZ);
                rotation.Value = rot;
            }

            else if (translation.Value.x > 11)
            {
                rot = Quaternion.Euler(0, 0, angleZ * - 1);
                rotation.Value = rot;
            }

            else if (translation.Value.x < -11)
            {
                rot = Quaternion.Euler(0, 0, angleZ * -1);
                rotation.Value = rot;
            }*/

        });
    }


}

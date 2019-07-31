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
        Entities.ForEach((ref Translation translation, ref BulletComponent bulletComponent, ref Rotation rotation) =>
        {

            //Bullet Movement            
            Quaternion rot = rotation.Value;
            //float angleZ = rot.eulerAngles.z; 
            Vector3 pos = translation.Value;
            Vector3 posChange = new Vector3(0, bulletComponent.moveSpeed * Time.deltaTime, 0);
            pos += rot * posChange;
            translation.Value = pos;

            //Raycast
            UnityEngine.RaycastHit hit;
            UnityEngine.Ray CheckBulletHit1 = new UnityEngine.Ray(new Vector3(pos.x - 0.1f, pos.y, pos.z), Quaternion.Euler(new Vector3(rot.eulerAngles.z, rot.eulerAngles.y, rot.eulerAngles.x)) * Vector3.forward);
            UnityEngine.Ray CheckBulletHit2 = new UnityEngine.Ray(new Vector3(pos.x + 0.1f, pos.y, pos.z), Quaternion.Euler(new Vector3(rot.eulerAngles.z, rot.eulerAngles.y, rot.eulerAngles.x)) * Vector3.forward);

            Debug.DrawRay(new Vector3(pos.x - 0.1f, pos.y, pos.z), Quaternion.Euler(new Vector3(rot.eulerAngles.z,rot.eulerAngles.y,rot.eulerAngles.x)) * Vector3.forward);
            Debug.DrawRay(new Vector3(pos.x + 0.1f, pos.y, pos.z), Quaternion.Euler(new Vector3(rot.eulerAngles.z, rot.eulerAngles.y, rot.eulerAngles.x)) * Vector3.forward);

    

            if (Physics.Raycast(CheckBulletHit1, out hit, 2f) || Physics.Raycast(CheckBulletHit2, out hit, 2f))
            {
                if (hit.transform.tag == "Enemy")
                {

                    float scale = hit.transform.localScale.y+0.1f;
                    if (pos.z> hit.transform.position.z - scale)
                    {
                        //hit.transform.GetComponent<ECSCollision>().DestroyOnHit();
                        hit.transform.GetComponent<EnemyLife>().health--;
                        hit.transform.GetComponent<EnemyLife>().CheckHealth(true);
                        
                    }
                    
                }
            }




            /* //Bullet Physics
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

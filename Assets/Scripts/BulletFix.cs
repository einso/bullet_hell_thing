using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFix : MonoBehaviour
{
    public Manager manager;
    public static int calls = 0;
    public static int spawns = 0;

    /*void Start()
    {
        spawns++;
        if(!this.name.Contains("EnemyProjectile"))
        {
            Debug.Log("spawn: " + spawns);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndWall")
        {
            manager.WaveEnemyNr--;
        }
    }
}
    //        calls++;
    //        //Debug.Log("calls: " + calls);
     
    //    {
    //        Debug.Log(other);
    //    }

   // }
   // }
   // }
   // }


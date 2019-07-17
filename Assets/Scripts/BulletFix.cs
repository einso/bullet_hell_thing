using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFix : MonoBehaviour
{
    public Manager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndWall")
        {
            manager.WaveEnemyNr--;
        }

    }
}

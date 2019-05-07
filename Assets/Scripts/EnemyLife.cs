using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float health = 1;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
}

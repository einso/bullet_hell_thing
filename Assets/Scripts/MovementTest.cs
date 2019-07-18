using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    float speed = 15;
    [HideInInspector]
    public Vector3 EnemyPos;

    void Update()
    {
        //Bullet Movement            
        transform.LookAt(EnemyPos);
        Quaternion rot = transform.rotation;
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(0, 0, speed * Time.deltaTime);
        pos += rot * posChange;
        transform.position = pos;             
    }
}

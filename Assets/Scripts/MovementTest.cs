using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    float speed = 15;

    void Update()
    {
        //Bullet Movement            
        Quaternion rot = transform.rotation;
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(0, speed * Time.deltaTime, 0);
        pos += rot * posChange;
        transform.position = pos;

        
    }
}

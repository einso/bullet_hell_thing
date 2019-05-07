using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float moveSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        //Bullet Movement            
        Quaternion rot = transform.rotation;
        float angleZ = rot.eulerAngles.z;
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(0, moveSpeed * Time.deltaTime, 0);
        pos += rot * posChange;
        transform.position = pos;
    }

}

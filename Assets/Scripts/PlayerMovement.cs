using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class PlayerMovement : MonoBehaviour
{

    public float playerMoveSpeed = 15;
    public float playerRotationSpeed = 15;


    private void Update()
    {

        //Rotate Player
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Rotation") * playerRotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Move Player
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime, 0);
        pos += rot * posChange;
        transform.position = pos;


        
    }
}

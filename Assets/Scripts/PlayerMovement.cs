using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Manager;
    public float playerMoveSpeed = 15;
    public float playerRotationSpeed = 15;
    public float playerShiftSpeed = 3;
    public float acceleration = 1;
    public float decceleration = 1;
    public GameObject hitParticlePrefab;
    [HideInInspector]
    public float speedBonusWhileSlow = 1;

    float moveHori;
    float moveVerti;


    private void Update()
    {
        //Rotate Player
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Rotation") * playerRotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(90, 0, 0);
        transform.rotation = rot;

        //Get Movement Input
        Vector3 pos = transform.position;

        //Calculate Acceleration
        //Vertical
        moveVerti += acceleration * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift)) moveVerti = Mathf.Clamp(moveVerti, -playerShiftSpeed, playerShiftSpeed);
        else moveVerti = Mathf.Clamp(moveVerti, -playerMoveSpeed, playerMoveSpeed);

        //Horizontal
        moveHori += acceleration * Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift)) moveHori = Mathf.Clamp(moveHori, -playerShiftSpeed, playerShiftSpeed);
        else moveHori = Mathf.Clamp(moveHori, -playerMoveSpeed, playerMoveSpeed);

        //Calculate Decceleration
        //Vertical
        if (Input.GetAxis("Vertical") == 0)
        {
            if (moveVerti > 0)
            {
                moveVerti -= decceleration;

                if (moveVerti < 0) moveVerti = 0;
            }

            else if (moveVerti < 0)
            {
                moveVerti += decceleration;

                if (moveVerti > 0) moveVerti = 0;
            }
        }

        //Horizontal
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (moveHori > 0)
            {
                moveHori -= decceleration;

                if (moveHori < 0) moveHori = 0;
            }

            else if (moveHori < 0)
            {
                moveHori += decceleration;

                if (moveHori > 0) moveHori = 0;
            }
        }

        //Set Movement Boundaries
        if (transform.position.x < -3.4f)
            {
                if (moveVerti < 0)
                {
                    moveVerti = 0;
                }
            }

        if (transform.position.x > 4.45f)
        {
            if (moveVerti > 0)
            {
                moveVerti = 0;
            }
        }

        if (transform.position.z < -4.57f)
        {
            if (moveHori < 0)
            {
                moveHori = 0;
            }
        }

        if (transform.position.z > 12.6f)
        {
            if (moveHori > 0)
            {
                moveHori = 0;
            }
        }

      /*  //Set Player to new Position
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 posChange = new Vector3(moveVerti / 5 * Time.deltaTime * speedBonusWhileSlow, moveHori / 5 * Time.deltaTime * speedBonusWhileSlow, 0);
            pos += rot * posChange;
            transform.position = pos;
        }
        else
        {*/
            Vector3 posChange = new Vector3(moveVerti * Time.deltaTime * speedBonusWhileSlow, moveHori * Time.deltaTime * speedBonusWhileSlow, 0);
            pos += rot * posChange;
            transform.position = pos;
       // }
    }
}

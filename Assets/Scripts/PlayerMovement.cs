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
    public GameObject hitParticlePrefab;
    [HideInInspector]
    public float speedBonusWhileSlow = 1;

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
        float moveHori = Input.GetAxis("Vertical");
        float moveVerti = Input.GetAxis("Horizontal");
        //bool moveHoriShift = Input.GetKey("Horizontal") && Input.GetKey("Shift");
        //bool moveVertiShift = Input.GetKey("Vertical") && Input.GetKey("Shift");

        //Set Movement Boundaries
        if (transform.position.x < -2.92f)
        {
            if(moveHori < 0)
            {
                moveHori = 0;
            }
        }

        if (transform.position.x > 4.3f)
        {
            if (moveHori > 0)
            {
                moveHori = 0;
            }
        }

        if (transform.position.z < -4.5f)
        {
            if (moveVerti < 0)
            {
                moveVerti = 0;
            }
        }

        if (transform.position.z > 12.5f)
        {
            if (moveVerti > 0)
            {
                moveVerti = 0;
            }
        }

        //Set Player to new Position
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 posChange = new Vector3(moveHori * playerShiftSpeed * Time.deltaTime * speedBonusWhileSlow, moveVerti * playerShiftSpeed * Time.deltaTime * speedBonusWhileSlow, 0);
            pos += rot * posChange;
            transform.position = pos;
        }
        else
        {
            Vector3 posChange = new Vector3(moveHori * playerMoveSpeed * Time.deltaTime * speedBonusWhileSlow, moveVerti * playerMoveSpeed * Time.deltaTime * speedBonusWhileSlow, 0);
            pos += rot * posChange;
            transform.position = pos;
        }
          

     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<Manager>().PlayerDeath();
            Instantiate(hitParticlePrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
}

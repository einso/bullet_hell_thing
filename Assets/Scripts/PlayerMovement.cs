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
    public GameObject hitParticlePrefab;

    void Start()
    {

    }

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
        float moveHori = Input.GetAxisRaw("Horizontal");
        float moveVerti = Input.GetAxisRaw("Vertical");

        //Set Movement Boundaries
        if (transform.position.x < -5f)
        {
            if(moveHori < 0)
            {
                moveHori = 0;
            }
        }

        if (transform.position.x > 5f)
        {
            if (moveHori > 0)
            {
                moveHori = 0;
            }
        }

        if (transform.position.z < -0.5f)
        {
            if (moveVerti < 0)
            {
                moveVerti = 0;
            }
        }

        if (transform.position.z > 8f)
        {
            if (moveVerti > 0)
            {
                moveVerti = 0;
            }
        }

        //Set Player to new Position
        Vector3 posChange = new Vector3(moveHori * playerMoveSpeed * Time.deltaTime, moveVerti * playerMoveSpeed * Time.deltaTime, 0);
        pos += rot * posChange;
        transform.position = pos;



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

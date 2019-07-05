using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    float moveSpeed = 20;
    GameObject player;

    float posX;
    float posY;
    float posZ;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 pos = transform.position;

        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        if (playerPos.z < pos.z)
        {
            posZ = posZ - 1 * moveSpeed *  Time.deltaTime;
            
        }

        if(transform.position.x > playerPos.x -0.5)
        {
            posX = posX - 1 * 5 * Time.deltaTime;
        }
        else if(transform.position.x < playerPos.x +0.5)
        {
            posX = posX + 1 * moveSpeed * Time.deltaTime;
        }

        if (playerPos.z > pos.z && transform.position.x > playerPos.x - 0.5 && transform.position.x < playerPos.x + 0.5)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector3(posX, posY, posZ);
    }
}

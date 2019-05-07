using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatterns : MonoBehaviour
{

    GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        FollowPlayerposX(Player, 5);
        
    }

    void FollowPlayerposX(GameObject FollowObject, float speed)
    {
        Vector3 FollowPos = FollowObject.transform.position;
        Vector3 Pos = transform.position;

        Debug.Log(FollowPos);

        if(Pos.x  < FollowPos.x - 0.3)
        {
            transform.position = new Vector3(Pos.x + 1 * speed * Time.deltaTime, Pos.y, Pos.z);
        }

        if (Pos.x > FollowPos.x + 0.3)
        {
            transform.position = new Vector3(Pos.x - 1 * speed * Time.deltaTime, Pos.y, Pos.z);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float moveSpeed = 20;
    public float angle = 2;
    GameObject player;
    GameObject manager;

    float posX;
    float posY;
    float posZ;

    [HideInInspector]
    public float manaValue;

    float distanceToPlayer;

    void Start()
    {
        player = GameObject.Find("Player");
        manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //take distance to player
        distanceToPlayer = transform.position.z - player.transform.position.z;

        //Move To Player
        if(transform.position.x>0.5f) transform.LookAt(new Vector3(player.transform.position.x + distanceToPlayer/angle, player.transform.position.y, player.transform.position.z));
        else transform.LookAt(new Vector3(player.transform.position.x - distanceToPlayer/angle, player.transform.position.y, player.transform.position.z));
        Quaternion rot = transform.rotation;
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        pos += rot * posChange;
        transform.position = pos;

        if(transform.position.z < player.transform.position.z)
        {
            //Give Mana
            manager.GetComponent<ManaBar>().manaAmount += manaValue;

            //Destroy
            Destroy(gameObject);
        }
    }
}

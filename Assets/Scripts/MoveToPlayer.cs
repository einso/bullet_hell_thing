using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    Vector3 playerSize = new Vector3(0.1910025f, 0.1910025f, 0.25467f);
    Vector3 playerSize2 = new Vector3(0.205f, 0.205f, 0.25467f);

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
        playerSize = new Vector3(0.1910025f, 0.1910025f, 0.25467f);
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

            //Player Feedback
            StartCoroutine(popPlayer());

            //Destroy
            //gameObject.SetActive(false);
        }
    }

    IEnumerator popPlayer()
    {
        player.transform.localScale = playerSize2;
        yield return new WaitForSeconds(0.075f);
        player.transform.localScale = playerSize;
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShortKeys : MonoBehaviour
{
    GameObject weapon;
    GameObject player;
    GameObject LevelCounter;
    GameObject manager;
    void Start()
    {
        weapon = GameObject.Find("FirePoint");
        player = GameObject.Find("Player");
        LevelCounter = GameObject.Find("level");
        manager = GameObject.Find("Manager");

        //Level Up UI Update
        LevelCounter.GetComponent<TextMeshProUGUI>().text = "Level: 1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<Manager>().amountOfKills = 0;
            manager.GetComponent<Manager>().Level1();
        }  
    
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel2;
            manager.GetComponent<Manager>().Level2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel3;
            manager.GetComponent<Manager>().Level3();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel4;
            manager.GetComponent<Manager>().Level4();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel5;
            manager.GetComponent<Manager>().Level5();
        }

        if(Input.GetKeyUp(KeyCode.G) && GetComponent<Manager>().GodMode == true)
        {
            GetComponent<Manager>().GodMode = false;
        }

        else if (Input.GetKeyUp(KeyCode.G) && GetComponent<Manager>().GodMode == false)
        {
            GetComponent<Manager>().GodMode = true;
        }
    }

}

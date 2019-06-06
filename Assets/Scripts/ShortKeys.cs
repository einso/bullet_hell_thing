using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortKeys : MonoBehaviour
{

    GameObject weapon; 

    void Start()
    {
        weapon = GameObject.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon.GetComponent<EntityCreater>().Baseshot = true;
            weapon.GetComponent<Weapon>().Baseshot = true;

            weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel3 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel4 = false;

            weapon.GetComponent<Weapon>().Playerlevel1 = false;
            weapon.GetComponent<Weapon>().Playerlevel2 = false;
            weapon.GetComponent<Weapon>().Playerlevel3 = false;
            weapon.GetComponent<Weapon>().Playerlevel4 = false;
        }  
    
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {   
            weapon.GetComponent<EntityCreater>().Playerlevel1 = true;
            weapon.GetComponent<Weapon>().Playerlevel1 = true;
 
            weapon.GetComponent<EntityCreater>().Baseshot = false;
            weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel3 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel4 = false;
      
            weapon.GetComponent<Weapon>().Baseshot = false;
            weapon.GetComponent<Weapon>().Playerlevel2 = false;
            weapon.GetComponent<Weapon>().Playerlevel3 = false;
            weapon.GetComponent<Weapon>().Playerlevel4 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon.GetComponent<EntityCreater>().Playerlevel2 = true;
            weapon.GetComponent<Weapon>().Playerlevel2 = true;

            weapon.GetComponent<EntityCreater>().Baseshot = false;
            weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel3 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel4 = false;

            weapon.GetComponent<Weapon>().Baseshot = false;
            weapon.GetComponent<Weapon>().Playerlevel1 = false;
            weapon.GetComponent<Weapon>().Playerlevel3 = false;
            weapon.GetComponent<Weapon>().Playerlevel4 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weapon.GetComponent<EntityCreater>().Playerlevel3 = true;
            weapon.GetComponent<Weapon>().Playerlevel3 = true;

            weapon.GetComponent<EntityCreater>().Baseshot = false;
            weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel4 = false;

            weapon.GetComponent<Weapon>().Baseshot = false;
            weapon.GetComponent<Weapon>().Playerlevel1 = false;
            weapon.GetComponent<Weapon>().Playerlevel2 = false;
            weapon.GetComponent<Weapon>().Playerlevel4 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            weapon.GetComponent<EntityCreater>().Playerlevel4 = true;
            weapon.GetComponent<Weapon>().Playerlevel4 = true;

            weapon.GetComponent<EntityCreater>().Baseshot = false;
            weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
            weapon.GetComponent<EntityCreater>().Playerlevel3 = false;

            weapon.GetComponent<Weapon>().Baseshot = false;
            weapon.GetComponent<Weapon>().Playerlevel1 = false;
            weapon.GetComponent<Weapon>().Playerlevel2 = false;
            weapon.GetComponent<Weapon>().Playerlevel3 = false;
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

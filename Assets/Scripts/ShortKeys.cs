using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShortKeys : MonoBehaviour
{
    GameObject weapon;
    GameObject player;
    GameObject LevelCounter;

    void Start()
    {
        weapon = GameObject.Find("FirePoint");
        player = GameObject.Find("Player");
        LevelCounter = GameObject.Find("level");

        //Level Up UI Update
        LevelCounter.GetComponent<TextMeshProUGUI>().text = "Level: 1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<Manager>().amountOfKills = 0;
            Level1();
        }  
    
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel2;
            Level2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel3;
            Level3();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel4;
            Level4();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GetComponent<Manager>().amountOfKills = GetComponent<Manager>().killsForLevel5;
            Level5();
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

    public void Level1()
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

        //Level Up UI Update
        LevelCounter.GetComponent<TextMeshProUGUI>().text = "Level: 1";
    }

    public void Level2()
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

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        LevelCounter.GetComponent<TextMeshProUGUI>().text = "Level: 2";
    }

    public void Level3()
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

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        LevelCounter.GetComponent<TextMeshProUGUI>().text = "Level: 3";
    }

    public void Level4()
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

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        LevelCounter.GetComponent<TextMeshProUGUI>().text = "Level: 4";
    }

    public void Level5()
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

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        LevelCounter.GetComponent<TextMeshProUGUI>().text = "Level: 5";
    }

    void SpawnLevelUPText()
    {
        Vector3 pos = new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z);
        Quaternion rot = Quaternion.Euler(90, 0, 90);
        GameObject levelUp = Instantiate(weapon.GetComponent<Weapon>().levelUPFeedback, pos, rot);
        levelUp.transform.SetParent(player.transform);
    }
}

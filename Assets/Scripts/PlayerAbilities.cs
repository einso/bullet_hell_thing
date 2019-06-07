using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    bool timeSlow;
    public float manaCostTime = 2;
    public float manaCostNuke = 200;
    [HideInInspector]
    public bool nukeEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Time Freeze
        if (Input.GetKeyDown(KeyCode.E) && !timeSlow)
        {
            timeSlow = true;
            TimeSlow();
        }
        else if (Input.GetKeyDown(KeyCode.E) && timeSlow)
        {
            timeSlow = false;
            TimeSlow();
        }

        //Mana Cost While Time Slow
        if(timeSlow)
        {
            GetComponent<ManaBar>().manaAmount -= manaCostTime;

            if(GetComponent<ManaBar>().manaAmount <= 0)
            {
                timeSlow = false;
                TimeSlow();
            }
        }

        //Enemy Nuke
        if (Input.GetKeyDown(KeyCode.Q) && manaCostNuke < GetComponent<ManaBar>().manaAmount)
        {
            nukeEnemy = true;
        }
        else if (nukeEnemy)
        {
            nukeEnemy = false;
            GetComponent<ManaBar>().manaAmount -= manaCostNuke;
        }
    }

    //Time Freeze
    void TimeSlow()
    {
        if(timeSlow)
        {
            Time.timeScale = 0.25f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}

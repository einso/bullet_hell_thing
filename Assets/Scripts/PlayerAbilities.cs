using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject nukepng;
    bool timeSlow;
    public float manaCostTime = 2f;
    public float manaCostNuke = 300f;
    [HideInInspector]
    public bool nukeEnemy;
    int transparence = 255;
    bool nukeVFX;
    bool nukeCD;
    float nukeTime;

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
        if (Input.GetKeyDown(KeyCode.Q) && manaCostNuke <= GetComponent<ManaBar>().manaAmount)
        {
            nukeEnemy = true;
        }
        else if (nukeEnemy)
        {
            nukeEnemy = false;
            GetComponent<ManaBar>().manaAmount -= manaCostNuke;
        }

        if(nukeEnemy)
        {
            nukeVFX = true;
        }

        if(nukeVFX)
        {
            nukeTime += 9 * Time.deltaTime;
            nukepng.GetComponent<Image>().color = Color32.Lerp(new Color32(255,255,255,0), new Color32(255, 255, 255, 255), nukeTime); 

            if(nukeTime >= 1)
            {                
                nukeVFX = false;
                nukeTime = 0;
                nukeCD = true;
            }            
        }

        if(nukeCD)
        {
            nukeTime += 0.5f * Time.deltaTime;
            nukepng.GetComponent<Image>().color = Color32.Lerp(new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), nukeTime);

            if (nukeTime >= 1)
            {
                nukeCD = false;
                nukeVFX = false;
                nukeTime = 0;
            }
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

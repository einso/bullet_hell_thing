using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject Player;
    public GameObject nukepng;
    [HideInInspector]
    public bool timeSlow;
    public float manaCostTime = 2f;
    public float manaCostNuke = 300f;
    [HideInInspector]
    public bool nukeEnemy;
    int transparence = 255;
    bool nukeVFX;
    bool nukeSFX;
    bool nukeCD;
    float nukeTime;
    public int nukeDamage;

    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<PlayerMovement>().speedBonusWhileSlow = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.activeInHierarchy)
        {
            //Time Freeze
            if (Input.GetButtonDown("TimeSlow") && !timeSlow)
            {
                timeSlow = true;
                TimeSlow();
            }
            else if (Input.GetButtonDown("TimeSlow") && timeSlow)
            {
                timeSlow = false;
                TimeSlow();
            }

            //Mana Cost While Time Slow
            if (timeSlow)
            {
                GetComponent<ManaBar>().manaAmount -= manaCostTime;

                if (GetComponent<ManaBar>().manaAmount <= 0)
                {
                    timeSlow = false;
                    TimeSlow();
                }
            }

            //Enemy Nuke
            if (Input.GetButtonDown("Nuke") && manaCostNuke <= GetComponent<ManaBar>().manaAmount)
            {
                nukeEnemy = true;
            }
            else if (nukeEnemy)
            {
                nukeEnemy = false;
                GetComponent<ManaBar>().manaAmount -= manaCostNuke;
            }

            if (nukeEnemy)
            {
                nukeVFX = true;
                nukeSFX = true;
            }

            if (nukeVFX)
            {
                nukeTime += 9 * Time.deltaTime;
                nukepng.GetComponent<Image>().color = Color32.Lerp(new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), nukeTime);

                if (nukeTime >= 1)
                {
                    nukeSFX = false;
                    nukeVFX = false;
                    nukeTime = 0;
                    nukeCD = true;
                }
            }

            if (nukeCD)
            {
                nukeTime += 1.3f * Time.deltaTime;
                nukepng.GetComponent<Image>().color = Color32.Lerp(new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), nukeTime);

                if (nukeTime >= 1)
                {
                    nukeCD = false;
                    nukeSFX = false;
                    nukeVFX = false;
                    nukeTime = 0;
                }
            }
        }
        else
        {
            timeSlow = false;
            TimeSlow();
            nukepng.SetActive(false);
        }
    }

    //Time Freeze
    void TimeSlow()
    {
        if(timeSlow)
        {
            Time.timeScale = 0.25f;
            if(Player != null) Player.GetComponent<PlayerMovement>().speedBonusWhileSlow = 4;

        }
        else
        {
            Time.timeScale = 1f;
            if (Player != null) Player.GetComponent<PlayerMovement>().speedBonusWhileSlow = 1;
        }
    }

}

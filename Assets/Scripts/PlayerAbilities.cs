﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Player;
    public GameObject nukepng;
    public GameObject miniNuke;
    [HideInInspector]
    public GameObject nuky;
    [HideInInspector]
    public bool timeSlow;
    public float manaCostTime = 2f;
    public float manaCostNuke = 300f;
    [HideInInspector]
    public bool nukeEnemy;
    [HideInInspector]
    public bool splitNuke;
    int transparence = 255;
    bool nukeVFX;
    bool nukeSFX;
    bool nukeCD;
    float nukeTime;
    public int nukeDamage;
    bool moveNuke;
    bool nukeInProcess;

    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<PlayerMovement>().speedBonusWhileSlow = 1;
    }

    // Update is called once per frame
    void Update()
    {       
        if (Time.timeScale > 0 && Player.activeInHierarchy)
        {
            //NEW NUKE
            if (Input.GetButtonDown("Nuke") && manaCostNuke <= GetComponent<ManaBar>().manaAmount && !nukeInProcess)
            {
                nukeInProcess = true;
                GetComponent<ManaBar>().manaAmount -= manaCostNuke;
                StartCoroutine(NukeProcess(1));
                Player.GetComponent<PlayerSounds>().PlayNukeSound();
            }

            IEnumerator NukeProcess(float Loading)
            {
                Player.transform.GetChild(0).GetComponent<Weapon>().enabled = false;
                Player.transform.GetComponent<Animator>().enabled = false;
                nuky = Instantiate(miniNuke);
                nuky.transform.parent = Player.transform;
                nuky.transform.localPosition = new Vector3(-1.5f, 1.9f, 0);
                yield return new WaitForSeconds(Loading);
                Player.transform.GetChild(0).GetComponent<Weapon>().enabled = true;
                moveNuke = true;
                nuky.transform.GetChild(1).gameObject.SetActive(true);
                nuky.transform.parent = null;
            }

            if (moveNuke)
            {
                if (nuky.transform.position.z < -20)
                    nuky.transform.position = new Vector3(nuky.transform.position.x, nuky.transform.position.y, nuky.transform.position.z + 10 * Time.deltaTime);
                else StartCoroutine((Boom()));

            }

            IEnumerator Boom()
            {
                splitNuke = true;
                nuky.SetActive(false);
                yield return new WaitForEndOfFrame();

                /*float rot = -15;

                for (int i = 0; i < 3; i++)
                {
                    GameObject boomy = Instantiate(miniNuke, nuky.transform.position, Quaternion.Euler(90, rot, 0));
                    boomy.transform.GetChild(1).gameObject.SetActive(true);
                    rot += 15;
                    boomy.GetComponent<MovementTest>().enabled = true;
                }*/


                moveNuke = false;
                splitNuke = false;
                Destroy(nuky);
                nukeInProcess = false;
            }


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

            /*  //Old Nuke
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
              }*/

        }
    }

    //Time Freeze
    void TimeSlow()
    {
        if (timeSlow)
        {
            Time.timeScale = 0.25f;
            if (Player != null) Player.GetComponent<PlayerMovement>().speedBonusWhileSlow = 4;

        }
        else 
        {
            Time.timeScale = 1f;
            if (Player != null) Player.GetComponent<PlayerMovement>().speedBonusWhileSlow = 1;
        }
       
    }

}

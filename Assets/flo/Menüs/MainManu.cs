using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour
{
    public int time;
    public bool MainMenübool = true;
    public bool settingsbool = false;
    public bool settingsbooltime = false;
    public int settingstime;
    [Header("Animatoren für die Menüs")]
    public Animator[] animMainMenüUI;
    public Animator[] animSettingsUI;
    public Animator[] animSettingssoundUI;
    public Animator[] animSettingscontrolsUI;
    public Animator[] animSettingsgrapficUI;
    public Animator[] animcontrolsUi;
    public Animator protagonist;
    int animatorlengh;

    [Header("Menüs")]
    public GameObject mainmenu;
    public GameObject settings;

    public void Update()
    {
        //time++;
        //if(MainMenübool == true)
        //{
        //    mainmenu.SetActive(true);
        //    settings.SetActive(false);
        //}

        //if (settingsbool == true && settingsbooltime == true)
        //{
        //    if (settingstime <= time)
        //    {
        //        mainmenu.SetActive(false);
        //        settings.SetActive(true);
        //    }
        //}
        //else if (settingsbool == true)
        //{
        //    settingstime = time;
        //    settingstime += 300;
        //    settingsbooltime = true;
        //}
    }
    public void Settingsstart()
    {
        protagonist.SetBool("Raus", true);
        for (int i = 0; i < animMainMenüUI.Length; i++)
        {
            animMainMenüUI[i].SetBool("Raus", true);
        }
        settingsbool = true;
    }
    public void Settingsquit()
    {
        protagonist.SetBool("Raus", false);
        settingsbool = false;
        settingsbooltime = false;
        MainMenübool = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour
{
    public int time;
    [Header("Animatoren für die Menüs")]
    public Animator[] animMainMenüUI;
    public Animator[] animSettingsUI;
    public Animator[] animcontrolsmenuUI;
    public Animator[] animSettingssoundUI;
    public Animator[] animSettingscontrolsUI;
    public Animator[] animSettingsgrapficUI;
    public Animator[] animcontrolsUi;
    public Animator protagonist;
    int animatorlengh;

    [Header("Menüs")]
    public GameObject mainmenu;
    public GameObject settings;
    public GameObject controlsmenu;

    [Header("Settingsoptionen")]
    public GameObject soundsettings;
    public GameObject scrensettings;
    public GameObject controlsettings;


    public void Update()
    {

    }
    public void Settingsstart()
    {
        protagonist.SetBool("Rein", false);
        protagonist.SetBool("Raus", true);
        for (int i = 0; i < animMainMenüUI.Length; i++)
        {
            animMainMenüUI[i].SetBool("Raus", true);
        }
        Invoke("menutosettings", 5);
    }
    public void Settingsquit()
    {
        animSettingsUI[0].SetBool("Raus", true);
        animSettingsUI[1].SetBool("Raus", true);
        animSettingscontrolsUI[0].SetBool("Raus", true);
        animSettingsgrapficUI[0].SetBool("Raus", true);
        animSettingssoundUI[0].SetBool("Raus", true);

        Invoke("settingstomenu", 5);
    }
    public void Controllmenu()
    {
        protagonist.SetBool("Rein", false);
        protagonist.SetBool("Raus", true);
        for (int i = 0; i < animMainMenüUI.Length; i++)
        {
            animMainMenüUI[i].SetBool("Raus", true);
        }
        Invoke("menutocontrolsmenu", 5);
    }
    public void Controllback()
    {
        animcontrolsmenuUI[0].SetBool("Raus", true);
        Invoke("controlsmenutomainmenu", 2.5f);
    }



    // Settings
    public void SettingsSound()
    {
        if(soundsettings.active == true)
        {

        }
        else
        {
            animSettingscontrolsUI[0].SetBool("Raus", true);
            animSettingsgrapficUI[0].SetBool("Raus", true);
            animSettingssoundUI[0].SetBool("Raus", true);
            Invoke("gotosound", 2);
        }
    }
    public void SettingsScreen()
    {
        if (scrensettings.active == true)
        {

        }
        else
        {
            animSettingscontrolsUI[0].SetBool("Raus", true);
            animSettingsgrapficUI[0].SetBool("Raus", true);
            animSettingssoundUI[0].SetBool("Raus", true);
            Invoke("gotoscreen", 2);
        }
    }
    public void settingscontrols()
    {
        if (controlsettings.active == true)
        {

        }
        else
        {
            animSettingscontrolsUI[0].SetBool("Raus", true);
            animSettingsgrapficUI[0].SetBool("Raus", true);
            animSettingssoundUI[0].SetBool("Raus", true);
            Invoke("gotocontrols", 2);
        }
    }
    void gotosound()
    {
        soundsettings.SetActive(true);
        scrensettings.SetActive(false);
        controlsettings.SetActive(false);
    }
    void gotoscreen()
    {
        soundsettings.SetActive(false);
        scrensettings.SetActive(true);
        controlsettings.SetActive(false);
    }
    void gotocontrols()
    {
        soundsettings.SetActive(false);
        scrensettings.SetActive(false);
        controlsettings.SetActive(true);
    }
    //settings



    void menutosettings()
    {
        protagonist.SetBool("Rein", false);
        mainmenu.SetActive(false);
        settings.SetActive(true);
    }
    void settingstomenu()
    {
        protagonist.SetBool("Raus", false);
        protagonist.SetBool("Rein", true);
        mainmenu.SetActive(true);
        settings.SetActive(false);
    }
    void menutocontrolsmenu()
    {
        protagonist.SetBool("Rein", false);
        mainmenu.SetActive(false);
        controlsmenu.SetActive(true);
    }
    void controlsmenutomainmenu()
    {
        protagonist.SetBool("Raus", false);
        protagonist.SetBool("Rein", true);
        mainmenu.SetActive(true);
        controlsmenu.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour
{

    [Header("Animatoren für die Menüs")]
    public Animator[] animMainMenüUI;
    public Animator[] animSettingsUI;
    public Animator[] animSettingssoundUI;
    public Animator[] animSettingscontrolsUI;
    public Animator[] animSettingsgrapficUI;
    public Animator[] animcontrolsUi;
    public Animator protagonist;
    int animatorlengh;
    

    [Header("Buttons Main Menü")]
    public GameObject mainmenu;

    [Header("Buttons/Slider und co Settings")]
    public GameObject settings;

    public void Update()
    {
        animatorlengh = animMainMenüUI.Length;
    }
    public void Settingsstart()
    {
        protagonist.SetBool("Raus", true);
        for (int i = 0; i < animMainMenüUI.Length; i++)
        {
            animMainMenüUI[i].SetBool("Raus", true);
        }

    }
}

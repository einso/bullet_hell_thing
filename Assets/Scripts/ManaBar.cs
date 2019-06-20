using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    bool regenOn;

    //MANA
    public Image bar;
    [HideInInspector]
    public float manaAmount;

    //NUKE
    [HideInInspector]
    public Image qGrey;
    public Image qBar;

    //TIMESLOW
    public Image eGrey;
    public Image eBar;

    // Start is called before the first frame update
    void Start()
    {
        //MANA BAR
        bar.fillAmount = 0;
        manaAmount = bar.fillAmount*1000;

        //Q BAR
        qBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //MANA BAR
        if (manaAmount < 0) manaAmount = 0;
        if (manaAmount > 1000) manaAmount = 1000;
        bar.fillAmount = manaAmount / 1000;

        //Q BAR               
        qBar.fillAmount = manaAmount / GetComponent<PlayerAbilities>().manaCostNuke;

        if (qBar.fillAmount >= 1)
        {
            qBar.GetComponent<Image>().color = new Color32(98, 147, 215, 255);
            qGrey.GetComponent<Image>().color = new Color32(69, 69, 69, 0);
        }

        if (qBar.fillAmount < 1) 
        {
            qBar.GetComponent<Image>().color = new Color32(157, 218, 224, 255);
            qGrey.GetComponent<Image>().color = new Color32(69, 69, 69, 180);
        }

        //E BAR 
        eBar.fillAmount = manaAmount / 1000;

        if (eBar.fillAmount > 0)
        {
            eGrey.GetComponent<Image>().color = new Color32(69, 69, 69, 0);
        }

        if (eBar.fillAmount == 0)
        {
            eGrey.GetComponent<Image>().color = new Color32(69, 69, 69, 180);
        }
    }




}

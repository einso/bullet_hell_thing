using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    bool regenOn;
    public Image bar;
    [HideInInspector]
    public float manaAmount;

    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 0;
        manaAmount = bar.fillAmount*1000;
    }

    // Update is called once per frame
    void Update()
    {

        if (manaAmount < 0) manaAmount = 0;
        if (manaAmount > 1000) manaAmount = 1000;
        bar.fillAmount = manaAmount / 1000;

    }



    
}

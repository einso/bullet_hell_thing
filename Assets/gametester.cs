using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gametester : MonoBehaviour
{
    public Manager scoremanager;
    public Text yourscore;
    public InputField yourname;
    public GameObject inputfield;
    public GameObject enterbutton;
    public GameObject usertext;
    public Text usernametext;
    public string username;

    void Update()
    {
        yourscore.text = "" + scoremanager.scoreCount;
        print(scoremanager.scoreCount);
        username = yourname.text;

        
    }
    public void Loghighscore()
    {
        usernametext.text = yourname.text;
        usertext.SetActive(true);
        inputfield.SetActive(false);
        enterbutton.SetActive(false);
        Higscore_dreamlo.AddNewHighscore(username, (int)scoremanager.scoreCount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gametester : MonoBehaviour
{
    public EventSystem eventSys;
    public GameObject restart;
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

        if(Input.GetMouseButtonDown(0))
        {
            eventSys.GetComponent<EventSystem>().SetSelectedGameObject(restart);
        }

    }
    public void Loghighscore()
    {
        usernametext.text = yourname.text;
        usertext.SetActive(true);
        inputfield.SetActive(false);
        enterbutton.SetActive(false);
        Higscore_dreamlo.AddNewHighscore(username, (int)scoremanager.scoreCount);
        eventSys.GetComponent<EventSystem>().SetSelectedGameObject(restart);
        yourscore.transform.position = new Vector3(restart.transform.position.x - 50, restart.transform.position.y+ 115,0);
    }
}

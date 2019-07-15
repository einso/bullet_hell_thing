using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text highscoregui;
    public float score;
    public float time;
    public float wave;
    public string ergebnis;
    public Manager highscoreholder;


    void Start()
    {
        Manager highscoreholder = GetComponent<Manager>();
        highscoregui.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    void Update()
    {
        score = highscoreholder.scoreCount;
        time = highscoreholder.time;
        wave = highscoreholder.waveNr;

        ergebnis = score.ToString() + " test ";
        
       // PlayerPrefs.SetInt("HighScore", ergebnis);


        Debug.Log("das ist der aktuelle score" + score + "  " + time + "  " + wave);

    }
}

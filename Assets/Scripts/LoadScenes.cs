using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public GameObject menue;
    public GameObject options;
    public GameObject Gegner1;
    public GameObject Gegner2;
    public GameObject Gegner3;

    public AudioClip testsound;
    public GameObject speaker;

    public void Start()
    {
        AudioManager.Instance.Play(testsound, speaker.transform);
    }
    //Load TitleScreen
    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
    }

    //Load Game
    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    //Quit Game   
    public void Quit()
    {
        Application.Quit();
    }

    //Options Menü
    public void Optionsstart()
    {
        menue.SetActive(false);
        options.SetActive(true);
        Gegner1.SetActive(false);
        Gegner2.SetActive(false);
        Gegner3.SetActive(false);
    }

    //options Back
    public void Optionsback()
    {
        menue.SetActive(true);
        options.SetActive(false);
        Gegner1.SetActive(true);
        Gegner2.SetActive(true);
        Gegner3.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{


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
}

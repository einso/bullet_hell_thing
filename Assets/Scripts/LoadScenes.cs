using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LoadScenes : MonoBehaviour
{
    public GameObject menue;
    public GameObject options;
    public GameObject Gegner1;
    public GameObject Gegner2;
    public GameObject Gegner3;

    //Load TitleScreen
    public void LoadScene0()
    {
        Time.timeScale = 1;
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


    
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
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


    //Einstellung Der Auflösung + Fulscrenn Einstelung//////////////////////////
    Resolution[] resolutions;
    public Dropdown resolutionDroptown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDroptown.ClearOptions();

        List<string> options = new List<string>();

        int currentResulutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResulutionIndex = i;
            }
        }

        resolutionDroptown.AddOptions(options);
        resolutionDroptown.value = currentResulutionIndex;
        resolutionDroptown.RefreshShownValue();
    }

    
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
/// //////////////////////////////////////////////
//Sound Einstellungen/////////////////////////////
    public Slider[] volumeSlieder;
    public AudioMixer audiomixer;

    public void SetMasterVolume(float volume)
    {
        audiomixer.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audiomixer.SetFloat("MusicVolume", volume);
    }
    public void SetSXFVolume(float volume)
    {
        audiomixer.SetFloat("SoundVolume", volume);
    }
}

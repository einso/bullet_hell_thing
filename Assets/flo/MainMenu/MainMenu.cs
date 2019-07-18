using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [Header("Alle Menüs")]
    public GameObject gMainMenü;
    public GameObject gSettings;
    public GameObject gControls;
    public GameObject gCredits;

    [Header("Animation Controller")]
    public GameObject test1;
    [Header("Sound Settings")]

    [Header("Screen Settings")]

    [Header("Settings")]
    public GameObject gScreenMenu;
    public GameObject gSoundMenu;
    public GameObject gControlsMenu;


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gCredits.active == true)
            {
                Back_To_MainMenu();
            }
        }
    }

    /// //////////////////////////////////////////////////////////////////////////
    /// Für Alle Wechsel Der Menüs
    /// //////////////////////////////////////////////////////////////////////////

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    
    //Buttons im MainMenu
    public void Settings()
    {
        Invoke("MainMenu_To_Settings", 1);
    }
    public void Controls()
    {
        Invoke("MainMenu_To_Controls", 1);
    }
    public void Credits()
    {
        Invoke("MainMenu_To_Credits", 1);
    }

    //Buttons im SettingsMenu
    public void SettingsSound()
    {
        Invoke("Settings_Go_To_Sound", 1);
    }
    public void SettingsScreen()
    {
        Invoke("Settings_Go_To_Screen", 1);
    }
    public void SettingsControls()
    {
        Invoke("Settings_Go_To_Controls", 1);
    }

    //quit zum Mainmenu aus jeder scene
    public void QuitToMainManu()
    {
        Invoke("Back_To_MainMenu", 1);
    }

    //Umschalter für die scenen
    void MainMenu_To_Settings()
    {
        gMainMenü.SetActive(false);
        gSettings.SetActive(true);
    }
    void MainMenu_To_Controls()
    {
        gMainMenü.SetActive(false);
        gControls.SetActive(true);
    }
    void MainMenu_To_Credits()
    {
        gMainMenü.SetActive(false);
        gCredits.SetActive(true);
        Invoke("Back_To_MainMenu", 55);
    }
    void Back_To_MainMenu()
    {
        gSettings.SetActive(false);
        gControls.SetActive(false);
        gCredits.SetActive(false);
        gMainMenü.SetActive(true);
    }
    void Settings_Go_To_Sound()
    {
        gSoundMenu.SetActive(true);
        gScreenMenu.SetActive(false);
        gControlsMenu.SetActive(false);
    }
    void Settings_Go_To_Screen()
    {
        gSoundMenu.SetActive(false);
        gScreenMenu.SetActive(true);
        gControlsMenu.SetActive(false);
    }
    void Settings_Go_To_Controls()
    {
        gSoundMenu.SetActive(false);
        gScreenMenu.SetActive(false);
        gControlsMenu.SetActive(true);
    }
    /// //////////////////////////////////////////////////////////////////////////
    /// Für Alle Wechsel Der Menüs
    /// //////////////////////////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////////////////////////
    /// Settings
    /// //////////////////////////////////////////////////////////////////////////


    /// //////////////////////////////////////////////////////////////////////////
    /// Settings
    /// //////////////////////////////////////////////////////////////////////////


}

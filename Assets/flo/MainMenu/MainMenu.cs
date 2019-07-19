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
    public Animator[] animMainmenu;
    public Animator[] animSettings;

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
        Invoke("MainMenu_To_Level", 3);
    }
    public void Quit()
    {
        Invoke("MainMenu_To_Quit", 3);
    }

    
    //Buttons im MainMenu
    public void Settings()
    {
        Invoke("MainMenu_To_Settings", 3);
        for (int i = 0; i < animMainmenu.Length; i++)
        {
            animMainmenu[i].SetBool("Raus", true);
        }
    }
    public void Controls()
    {
        Invoke("MainMenu_To_Controls", 3);
        for (int i = 0; i < animMainmenu.Length; i++)
        {
            animMainmenu[i].SetBool("Raus", true);
        }
    }
    public void Credits()
    {
        Invoke("MainMenu_To_Credits", 3);
        for (int i = 0; i < animMainmenu.Length; i++)
        {
            animMainmenu[i].SetBool("Raus", true);
        }
    }

    //Buttons im SettingsMenu
    public void SettingsSound()
    {
        Invoke("Settings_Go_To_Sound", 1.5f);
        animSettings[2].SetBool("Raus", true);
        animSettings[3].SetBool("Raus", true);
    }
    public void SettingsScreen()
    {
        Invoke("Settings_Go_To_Screen", 1.5f);
        animSettings[1].SetBool("Raus", true);
        animSettings[3].SetBool("Raus", true);
    }
    public void SettingsControls()
    {
        Invoke("Settings_Go_To_Controls", 1.5f);
        animSettings[1].SetBool("Raus", true);
        animSettings[2].SetBool("Raus", true);
    }

    //quit zum Mainmenu aus jeder scene
    public void QuitToMainManu()
    {
        Invoke("Back_To_MainMenu", 1.5f);
        for (int i = 0; i < animSettings.Length; i++)
        {
            animSettings[i].SetBool("Raus", true);
        }
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
    void MainMenu_To_Level()
    {
        SceneManager.LoadScene(1);
    }
    void MainMenu_To_Quit()
    {
        Application.Quit();
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

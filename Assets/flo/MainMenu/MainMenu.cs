using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject eve;
    public GameObject g;
    Transform unselectedTrans;

    [Header("Alle Menüs")]
    public GameObject gMainMenü;
    public GameObject gSettings;
    public GameObject gControls;
    public GameObject gCredits;
    public GameObject LoadingScreen;
    public GameObject LoadingBar;

    [Header("Animation Controller")]
    public Animator[] animMainmenu;
    public Animator[] animSettings;
    public Animator[] animControls;
    [Header("Sound Settings")]
    public Slider[] volumeSlieder;
    public AudioMixer audiomixer;

    [Header("Screen Settings")]
    Resolution[] resolutions;
    public Dropdown resolutionDroptown;

    [Header("Settings")]
    public GameObject gScreenMenu;
    public GameObject gSoundMenu;
    public GameObject gControlsMenu;

    private void Start()
    {
        gMainMenü.SetActive(true);

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

    public void Update()
    {
        eve.GetComponent<EventSystem>().SetSelectedGameObject(g);

        if (Input.GetKeyDown(KeyCode.Escape))
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
        Invoke("MainMenu_To_Level", 0);
        

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
        animControls[0].SetBool("Raus", true);
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
        Invoke("Back_To_MainMenu", 20);
    }
    void Back_To_MainMenu()
    {
        gSettings.SetActive(false);
        gControls.SetActive(false);
        gCredits.SetActive(false);
        gMainMenü.SetActive(true);
        Debug.Log("miau1");
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
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously ()
    {
         AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingBar.GetComponent<Slider>().value = progress;
            yield return null;
        }
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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    //Select Button
    public void SelectButton()
    {
        g = EventSystem.current.currentSelectedGameObject;

        unselectedTrans = g.transform;

        g.transform.localScale = unselectedTrans.localScale * 1.2f;
    }

    public void DeSelectButton()
    {
        g.transform.localScale = new Vector3(1, 1, 1);
    }

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

    /// //////////////////////////////////////////////////////////////////////////
    /// Settings
    /// //////////////////////////////////////////////////////////////////////////


}

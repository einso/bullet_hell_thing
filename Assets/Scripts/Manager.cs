using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{
    public float changeButtonSize = 1.2f;
    public bool GodMode;
    [Space(20)]

    [HideInInspector]
    public int playerLevelValue;

    public GameObject Player;
    public GameObject Camera;
    public GameObject DeathScreen;
    public GameObject PauseScreen;
    public GameObject scoreGUI;
    public GameObject timeGUI;
    public GameObject levelGUI;
    public GameObject waveNrGUI;
    public GameObject lootParticle;
    public GameObject levelParticle;
    public GameObject waveProgress;
    public GameObject UI;
    public GameObject backgroundLayers;
    public string[] waveProgressMessages;
    GameObject SpawnPos1;

    public float minEnemySpawnTime = 0f;
    public float maxEnemySpawnTime = 4f;

    //Player Level UP
    public float killsForLevel2;
    public float killsForLevel3;
    public float killsForLevel4;
    public float killsForLevel5;

    public Weapon weapon;

    [HideInInspector]
    public float amountOfKills;

    [HideInInspector]
    public int waveCicle = 0;

    public float time;
    public float waveNr;

    int presetWaveNr = 0;

    bool dontSpawnRandomWaves;
    bool doCoroutineOnce;

    [HideInInspector]
    public int amountOfProbabilities;

    [Space(20)]
    public GameObject[] enemyPrefabs;
    public int[] enemyProbabilities;
    [Space(20)]

    public GameObject[] presetWaves;
    [Space(20)]
    public int waveSize = 3;
    public float maxSecNextEnemySpawn = 0f;
    public float minSecNextEnemySpawn = 0.2f;
    float randSecNextEnemySpawn;
    public float secondsTillNextWave = 10;
    float t = 10;
    public float scoreCount;
    [HideInInspector]
    public float levelCount = 1f;

    [HideInInspector]
    public int WaveEnemyNr = 0;
    //public int NumberOfEnemies;

    bool showWaveProgress;
    bool throwAwayWaveFeedback;

    bool startGame;
    bool startAni;

    float scrollSpeedLayer1;
    float scrollSpeedLayer2;
    float scrollSpeedLayer3;

    Transform unselectedTrans;
    GameObject g;

    // Start is called before the first frame update
    void Start()
    {
       


        //RESET HIGSCORE
        //PlayerPrefs.SetFloat("HighestScore", 0);


        Player.transform.position = new Vector3(0.5f, 1, -9);
        UI.SetActive(false);

        scrollSpeedLayer1 = backgroundLayers.transform.GetChild(0).GetComponent<ScrollingBackground>().scrollSpeed;
        scrollSpeedLayer2 = backgroundLayers.transform.GetChild(1).GetComponent<ScrollingBackground>().scrollSpeed;
        scrollSpeedLayer3 = backgroundLayers.transform.GetChild(2).GetComponent<ScrollingBackground>().scrollSpeed;

        backgroundLayers.transform.GetChild(0).GetComponent<ScrollingBackground>().scrollSpeed = 0;
        backgroundLayers.transform.GetChild(1).GetComponent<ScrollingBackground>().scrollSpeed = 0;
        backgroundLayers.transform.GetChild(2).GetComponent<ScrollingBackground>().scrollSpeed = 0;
        //SpawnWave();
        //randSecNextEnemySpawn = time;      //Set Time you need to spawn the first enemy

        Time.timeScale = 1;                //Set Time to 1

        t = secondsTillNextWave;

        AmountOfProbabilities();           //Set the amount of probabilities
        scoreCount = 0;


        //// screen resolution
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


    // Update is called once per frame
    void Update()
    {

        if (startGame)
        {
            if (Player != null)
            {
                //Take Game Time
                time = time + 1 * Time.deltaTime;

                //SpawnWave
                WaveManagement();

                //GUI Update
                scoreGUI.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreCount;
                timeGUI.GetComponent<TextMeshProUGUI>().text = "Time to next  Wave: " + t.ToString("0");
                //levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: "+levelCount;
                waveNrGUI.GetComponent<TextMeshProUGUI>().text = "Wave: " + waveNr;

                //WaveProgresionFeedback
                WaveProgressionFeedback(20);

                //PauseGame
                PauseGame();

                //PlayerLevelUP
                PlayerLevelUP();

                //GodMode
                ToggleGodMode();
            }

        }
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 5 * Time.deltaTime);

            if (Player.transform.position.z > -1)
            {
                startGame = true;
                UI.SetActive(true);
                Player.GetComponent<PlayerMovement>().enabled = true;
                backgroundLayers.transform.GetChild(0).GetComponent<ScrollingBackground>().scrollSpeed = scrollSpeedLayer1;
                backgroundLayers.transform.GetChild(1).GetComponent<ScrollingBackground>().scrollSpeed = scrollSpeedLayer2;
                backgroundLayers.transform.GetChild(2).GetComponent<ScrollingBackground>().scrollSpeed = scrollSpeedLayer3;
            }
        }
    }


    //Wave management
    void WaveManagement()
    {
        //allow/disallow wave spawning
        if (WaveEnemyNr > 25)   //Dont spawn waves if too many enemies
        {
            dontSpawnRandomWaves = true;
        }
        else if (presetWaveNr < presetWaves.Length ) //Dont spawn Waves while preset waves are still active
        {
            dontSpawnRandomWaves = true;
        }
        else
        {
            dontSpawnRandomWaves = false;
        }

        //Preset Wave System
        if(dontSpawnRandomWaves)
        {
            if (WaveEnemyNr < 1)
            {
                if (!doCoroutineOnce) StartCoroutine(SpawnPresetWave(1)); //Spawn Preset Wave

                if (presetWaves[presetWaveNr] != null) //Check if null
                {
                    if (presetWaves[presetWaveNr].transform.childCount == 0 ) //If wave is cleared
                    {
                        presetWaves[presetWaveNr].SetActive(false); //Destroy empty Wave
                        presetWaveNr++; //count wave number + 1
                        t = secondsTillNextWave;                        
                    }
                }
            }
            else
            {
                t -= 1 * Time.deltaTime;

                if (t < 0)  //If timer hit 0
                {
                    presetWaveNr++; //count wave number + 1
                    presetWaves[presetWaveNr].SetActive(true); //Spawn Preset Wave
                    WaveEnemyNr += presetWaves[presetWaveNr].transform.childCount; //Count how many enemies spawned
                    t = secondsTillNextWave;    //Reset time
                    waveNr++;                   //Count wave number for UI
                    WaveFeedbackTrigger();
                }
            }
        }


        //Random Wave System
        if (!dontSpawnRandomWaves)
        {
            if (WaveEnemyNr < 1 && !doCoroutineOnce)    //If no Enemies are Left
            {
                StartCoroutine(WaveDelay());    //Spawn Next Wave
            }
            else
            {
                t -= 1 * Time.deltaTime;

                if (t < 0)  //If timer hit 0
                {
                    SpawnWave();    //Spawn next wave
                    LoadWave();     //Load next wave
                    t = secondsTillNextWave;    //Reset time
                    waveNr++;                   //Count wave number for UI
                    WaveFeedbackTrigger();
                }
            }
        }


        //Wave Delay
        IEnumerator WaveDelay()
        {
            doCoroutineOnce = true;
            yield return new WaitForSeconds(1);
            doCoroutineOnce = false;
            SpawnWave();
            LoadWave();
            t = secondsTillNextWave;
            waveNr++;
            WaveFeedbackTrigger(); //Wave Progress Feedback
        }
    }

    //Spawn Preset Wave
    IEnumerator SpawnPresetWave(float delay)
    {
        doCoroutineOnce = true;
        yield return new WaitForSeconds(delay);
        doCoroutineOnce = false;
        presetWaves[presetWaveNr].SetActive(true); //Spawn Preset Wave
        WaveEnemyNr += presetWaves[presetWaveNr].transform.childCount; //Count how many enemies spawned
        waveNr++;   //Wave Nr UI +1 
        WaveFeedbackTrigger(); //Wave Progress Feedback
    }

    //Generate a random number to detect which type of enemy should spawn next
    int randProbability()
    {
        int randomEnemy = Random.Range(1, AmountOfProbabilities()+1);   //random number between 0 and total of all probabilities
        int probabilityPool = 0;                                    //reset probabilitypool

        //check for each enemy if the random number is inside the probabilityPool
        for (int i = 0; i < enemyProbabilities.Length; i++)
        {
            probabilityPool += enemyProbabilities[i];   

            if (probabilityPool >= randomEnemy)  
            {                
                return i;   //return index to spawn enemy with same index
            }
        }
        Debug.LogError("Du musst noch Wahrscheinlichkeiten einstellen");
        return 0;
    }


    //Create pool of probabilities
    public int AmountOfProbabilities()
    {
        amountOfProbabilities = 0;

        //Get Total of all probabilities in the enemyProbabilities Array
        for (int i = 0; i < enemyProbabilities.Length; i++)
        {
            amountOfProbabilities += enemyProbabilities[i];
        }
        return amountOfProbabilities;
    }

    //SpawnEnemyEvent
    void SpawnEnemy()
    {
        //NumberOfEnemies++;
        float spawnPosX = Random.Range(0, 8.13f);

        //Spawn Enemy and Set Position
        GameObject instance = Instantiate(enemyPrefabs[randProbability()], new Vector3(spawnPosX - 3.4f, 1f, Camera.transform.position.z + 9.7f), transform.rotation);
        //instance.GetComponent<SinusoidalMove>().moveSpeed = Random.Range(2, 15);
        //instance.GetComponent<SinusoidalMove>().frequency = Random.Range(2, 15);
    }

    //SpawnWaveEvent
    void SpawnWave()
    {
        //Spawn number of Enemies depending on waveSize
        for (int i = 0; i < waveSize; i++)
        {
            StartCoroutine(EnemySpawnDelay()); //Delay enemies during wave
            WaveEnemyNr++;  //Count enemies inside wave
        }

        
    }

    IEnumerator EnemySpawnDelay()
    {
        float rand = Random.Range(minEnemySpawnTime, maxEnemySpawnTime);
        yield return new WaitForSeconds(rand);
        SpawnEnemy();
    }

    void LoadWave()
    {
        if (GetComponent<LoadLevel>().Level_1)
        {
            GetComponent<LoadLevel>().Level_1 = false;
            GetComponent<LoadLevel>().Level_2 = true;
        }
        else if (GetComponent<LoadLevel>().Level_2)
        {
            GetComponent<LoadLevel>().Level_2 = false;
            GetComponent<LoadLevel>().Level_3 = true;
        }
        else if (GetComponent<LoadLevel>().Level_3)
        {
            GetComponent<LoadLevel>().Level_3 = false;
            GetComponent<LoadLevel>().Level_4 = true;
        }
        else if (GetComponent<LoadLevel>().Level_4)
        {
            GetComponent<LoadLevel>().Level_4 = false;
            GetComponent<LoadLevel>().Level_5 = true;
        }
        else if (GetComponent<LoadLevel>().Level_5)
        {
            GetComponent<LoadLevel>().Level_5 = false;
            GetComponent<LoadLevel>().Level_6 = true;
        }
        else if (GetComponent<LoadLevel>().Level_6)
        {
            GetComponent<LoadLevel>().Level_6 = false;
            GetComponent<LoadLevel>().Level_1 = true;
            waveCicle++;
        }
    }

    public void PlayerLevelUp()
    {
       if (scoreCount >= 0)
        {
            levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: " + levelCount;
            Debug.Log("you leveled up!");
        }
    }

    //PlayerDeathEvent
    public void PlayerDeath()
    {
        DeathScreen.SetActive(true);
    }

    //EnemyDeathEvent
    public void EnemyDeathEvent(GameObject Manager, GameObject other,GameObject scoreFeedbackPrefab,GameObject HitEnemyParticle, GameObject DestroyEnemyParticle, bool dropXP)
    {

        //CALCULATE AMOUNT OF KILLS
        amountOfKills++;

        //CALCULATE SCORE
        float scoreValue = other.GetComponent<SinusoidalMove>().scoreValue;
        FindObjectOfType<Manager>().scoreCount += scoreValue;
        //GetComponent<Manager>().scoreCount += scoreValue;

        //SHOW SCORE OVER ENEMY
        GameObject scoreFeedback = Instantiate(scoreFeedbackPrefab, new Vector3(other.transform.position.x +4.73f, other.transform.position.y , other.transform.position.z-0.4f), scoreFeedbackPrefab.transform.rotation);
        scoreFeedback.GetComponent<TextMeshPro>().text = "" + other.GetComponent<SinusoidalMove>().scoreValue;

        //Spawn Particle Effect
        GameObject destroyParticle = Instantiate(DestroyEnemyParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.Euler(0,0,0));
        //Instantiate(HitEnemyParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);

        if(dropXP)
        {
            GameObject lootMyAss = Instantiate(lootParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.Euler(0, 0, 0));
            lootMyAss.GetComponent<MoveToPlayer>().manaValue = other.GetComponent<EnemyLife>().giveMana;
        }

        //MinusWaveNumber
        FindObjectOfType<Manager>().WaveEnemyNr--;
    }

    //PauseGameEvent
    public void PauseGame()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !PauseScreen.activeSelf && !DeathScreen.activeInHierarchy)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        else if (Input.GetKeyUp(KeyCode.Escape) && PauseScreen.activeSelf)
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
            if (GetComponent<PlayerAbilities>().timeSlow) Time.timeScale = 0.25f;
            g.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //ContinueEvent   
    public void Continue()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
        if (GetComponent<PlayerAbilities>().timeSlow) Time.timeScale = 0.25f;
    }

    //ToggleGodMode
    void ToggleGodMode()
    {
        if(Player.activeInHierarchy)
        {
            if (GodMode)
            {
                Player.GetComponentInChildren<Collider>().enabled = false;
            }
            else
            {
                Player.GetComponentInChildren<Collider>().enabled = true;
            }
        }
    }
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public GameObject menue;
    public GameObject options;
    //Options Menü
    public void Optionsstart()
    {
        menue.SetActive(false);
        options.SetActive(true);
        
    }

    //options Back
    public void Optionsback()
    {
        menue.SetActive(true);
        options.SetActive(false);
        Debug.Log("test");
    }


    //Einstellung Der Auflösung + Fulscrenn Einstelung//////////////////////////
    Resolution[] resolutions;
    public Dropdown resolutionDroptown;




    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
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

    //PlayerLevelUP
    public void PlayerLevelUP()
    {
        if (weapon.Baseshot)
        {
            if (amountOfKills > killsForLevel2) Level2();
        }

        if (weapon.Playerlevel1)
        {
            if (amountOfKills > killsForLevel3) Level3();
        }

        if (weapon.Playerlevel2)
        {
            if (amountOfKills > killsForLevel4) Level4();
        }

        if (weapon.Playerlevel3)
        {
            if (amountOfKills > killsForLevel5) Level5();
        }

    }

    public void Level1()
    {

        weapon.GetComponent<EntityCreater>().Baseshot = true;
        weapon.GetComponent<Weapon>().Baseshot = true;

        weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel3 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel4 = false;

        weapon.GetComponent<Weapon>().Playerlevel1 = false;
        weapon.GetComponent<Weapon>().Playerlevel2 = false;
        weapon.GetComponent<Weapon>().Playerlevel3 = false;
        weapon.GetComponent<Weapon>().Playerlevel4 = false;

        playerLevelValue = 0;

        //Level Up UI Update
        levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: 1";
    }

    public void Level2()
    {
        weapon.GetComponent<EntityCreater>().Playerlevel1 = true;
        weapon.GetComponent<Weapon>().Playerlevel1 = true;

        weapon.GetComponent<EntityCreater>().Baseshot = false;
        weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel3 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel4 = false;

        weapon.GetComponent<Weapon>().Baseshot = false;
        weapon.GetComponent<Weapon>().Playerlevel2 = false;
        weapon.GetComponent<Weapon>().Playerlevel3 = false;
        weapon.GetComponent<Weapon>().Playerlevel4 = false;

        playerLevelValue = 1;

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: 2";
    }

    public void Level3()
    {
        weapon.GetComponent<EntityCreater>().Playerlevel2 = true;
        weapon.GetComponent<Weapon>().Playerlevel2 = true;

        weapon.GetComponent<EntityCreater>().Baseshot = false;
        weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel3 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel4 = false;

        weapon.GetComponent<Weapon>().Baseshot = false;
        weapon.GetComponent<Weapon>().Playerlevel1 = false;
        weapon.GetComponent<Weapon>().Playerlevel3 = false;
        weapon.GetComponent<Weapon>().Playerlevel4 = false;

        playerLevelValue = 2;

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: 3";
    }

    public void Level4()
    {
        weapon.GetComponent<EntityCreater>().Playerlevel3 = true;
        weapon.GetComponent<Weapon>().Playerlevel3 = true;

        weapon.GetComponent<EntityCreater>().Baseshot = false;
        weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel4 = false;

        weapon.GetComponent<Weapon>().Baseshot = false;
        weapon.GetComponent<Weapon>().Playerlevel1 = false;
        weapon.GetComponent<Weapon>().Playerlevel2 = false;
        weapon.GetComponent<Weapon>().Playerlevel4 = false;

        playerLevelValue = 3;

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: 4";
    }

    public void Level5()
    {
        weapon.GetComponent<EntityCreater>().Playerlevel4 = true;
        weapon.GetComponent<Weapon>().Playerlevel4 = true;

        weapon.GetComponent<EntityCreater>().Baseshot = false;
        weapon.GetComponent<EntityCreater>().Playerlevel1 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel2 = false;
        weapon.GetComponent<EntityCreater>().Playerlevel3 = false;

        weapon.GetComponent<Weapon>().Baseshot = false;
        weapon.GetComponent<Weapon>().Playerlevel1 = false;
        weapon.GetComponent<Weapon>().Playerlevel2 = false;
        weapon.GetComponent<Weapon>().Playerlevel3 = false;

        playerLevelValue = 4;

        //Level Up Feedback
        SpawnLevelUPText();

        //Level Up UI Update
        levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: 5";
    }

    //Show Level Up Above Player
    void SpawnLevelUPText()
    {
        Vector3 pos = new Vector3(Player.transform.position.x - 1f, Player.transform.position.y, Player.transform.position.z);
        Quaternion rot = Quaternion.Euler(90, 0, 90);
        GameObject levelUp = Instantiate(weapon.GetComponent<Weapon>().levelUPFeedback, pos, rot);
        levelUp.transform.SetParent(Player.transform);

        GameObject levelPartInst = Instantiate(levelParticle, new Vector3(Player.transform.position.x +0.7f, Player.transform.position.y, Player.transform.position.z), levelParticle.transform.rotation);
        levelPartInst.transform.SetParent(Player.transform);
    }

    //Select Button
    public void SelectButton()
    {
        g = EventSystem.current.currentSelectedGameObject;

        unselectedTrans = g.transform;

        g.transform.localScale = unselectedTrans.localScale * changeButtonSize;
    }

    public void DeSelectButton()
    {
        g.transform.localScale = new Vector3(1,1,1);
    }
        
    //Set Wave Progression Feedback true 
    void WaveFeedbackTrigger()
    {
        showWaveProgress = true;
        waveProgress.transform.position = new Vector3(-3.28f, 1, 15);
        int messageOrNumber = Random.Range(0, 3);

        if(waveProgressMessages.Length < 1)
        {
            if (waveNr == 69) waveProgress.GetComponentInChildren<TextMeshPro>().text = "Wave: "+waveNr+" ( ͡° ͜ʖ ͡°)";
            else waveProgress.GetComponentInChildren<TextMeshPro>().text = "Wave: " + waveNr;
        }
        else if (waveNr > 3)
        {
            if (messageOrNumber == 0) waveProgress.GetComponentInChildren<TextMeshPro>().text = "Wave: " + waveNr;
            else
            {
                int randomMessage = Random.Range(0, waveProgressMessages.Length);
                waveProgress.GetComponentInChildren<TextMeshPro>().text = waveProgressMessages[randomMessage];
            }
        }
        else
        {
            waveProgress.GetComponentInChildren<TextMeshPro>().text = "Wave: " + waveNr;
        }
    }

    //WaveProgessionFeedback
    void WaveProgressionFeedback(float speed)
    {
        if(showWaveProgress)
        {
            if (waveProgress.transform.position.z > 4.2f)
            {
                waveProgress.transform.position = new Vector3(waveProgress.transform.position.x, waveProgress.transform.position.y, waveProgress.transform.position.z - speed * Time.deltaTime);
            } 
            else
            {
                StartCoroutine(SetThrowAwayTrue());
            }
        }         
        
        if(throwAwayWaveFeedback)
        {
            if(waveProgress.transform.position.z > -10)
            {
                waveProgress.transform.position = new Vector3(waveProgress.transform.position.x, waveProgress.transform.position.y, waveProgress.transform.position.z - speed * Time.deltaTime);
            }
            else
            {
                throwAwayWaveFeedback = false;
            }
        }
    }

    IEnumerator SetThrowAwayTrue()
    {
        showWaveProgress = false;
        yield return new WaitForSeconds(1);
        throwAwayWaveFeedback = true;
    }
}

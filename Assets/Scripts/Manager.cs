using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public bool GodMode;
    [Space(20)]

    public GameObject Player;
    public GameObject Camera;
    public GameObject DeathScreen;
    public GameObject PauseScreen;
    public GameObject scoreGUI;
    public GameObject timeGUI;
    public GameObject levelGUI;
    public GameObject waveNrGUI;
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

    float time;
    float waveNr;

    bool dontSpawnWaves;
    bool doCoroutineOnce;

    [HideInInspector]
    public int amountOfProbabilities;

    [Space(20)]
    public GameObject[] enemyPrefabs;
    public int[] enemyProbabilities;
    [Space(20)]

    public int waveSize = 3;
    public float maxSecNextEnemySpawn = 0f;
    public float minSecNextEnemySpawn = 0.2f;
    float randSecNextEnemySpawn;
    public float secondsTillNextWave = 10;
    float t = 0;
    public float scoreCount;
    [HideInInspector]
    public float levelCount = 1f;

    [HideInInspector]
    public int WaveEnemyNr = 0;
    //public int NumberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;                //Set Time to 1
        randSecNextEnemySpawn = time;      //Set Time you need to spawn the first enemy

        AmountOfProbabilities();           //Set the amount of probabilities
        scoreCount = 0;        
    }

   

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            //Take Game Time
            time = time + 1 * Time.deltaTime;

            //SpawnEnemy
            /* if (time > randSecNextEnemySpawn)
             {
                 SpawnEnemy();                                                                               //Spawn enemy
                 time = 0;                                                                                   //Reset time
                 randSecNextEnemySpawn = Random.Range(minSecNextEnemySpawn, maxSecNextEnemySpawn);           //Set new random spawn time 
             }*/

            //SpawnWave
            WaveManagement();

            //GUI Update
            scoreGUI.GetComponent<TextMeshProUGUI>().text = "Score: "+scoreCount;
            timeGUI.GetComponent<TextMeshProUGUI>().text = "Time: " + Time.timeSinceLevelLoad.ToString("0");
            //levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: "+levelCount;
            waveNrGUI.GetComponent<TextMeshProUGUI>().text = "Wave: " + waveNr;

            //PauseGame
            PauseGame();

            //PlayerLevelUP
            PlayerLevelUP();

            //GodMode
            ToggleGodMode();
        }
    }


    IEnumerator WaveDelay()
    {
        doCoroutineOnce = true;
        yield return new WaitForSeconds(1);
        doCoroutineOnce = false;
        SpawnWave();
        LoadWave();
        t = 0;
        waveNr++;
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
    IEnumerator EnemySpawnDelay()
    {
        float rand = Random.Range(minEnemySpawnTime, maxEnemySpawnTime);
        yield return new WaitForSeconds(rand);
        SpawnEnemy();
    }

    void SpawnWave()
    {
        for (int i = 0; i < waveSize; i++)
        {
            StartCoroutine(EnemySpawnDelay());
            WaveEnemyNr++;
        }        
    }

    void WaveManagement()
    {
        if(!dontSpawnWaves)
        {
            if (WaveEnemyNr < 1 && !doCoroutineOnce)
            {
                StartCoroutine(WaveDelay());
            }
            else
            {
                t += 1 * Time.deltaTime;

                if (t > secondsTillNextWave)
                {
                    SpawnWave();
                    LoadWave();
                    t = 0;
                    waveNr++;
                }
            }
        }


        if(WaveEnemyNr > 25)
        {
            dontSpawnWaves = true;
        }
        else
        {
            dontSpawnWaves = false;
        }
    }

   /* void SpawnNumber()
    {
        for (int i = 0; i < spawnsAtOnce; i++)
        {
            Invoke("SpawnEnemy", 1);
        }
    }*/

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
    public void EnemyDeathEvent(GameObject Manager, GameObject other,GameObject scoreFeedbackPrefab,GameObject HitEnemyParticle, GameObject DestroyEnemyParticle)
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

        //MinusWaveNumber
        FindObjectOfType<Manager>().WaveEnemyNr--;
    }

    //PauseGameEvent
    public void PauseGame()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !PauseScreen.activeSelf)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        else if (Input.GetKeyUp(KeyCode.Escape) && PauseScreen.activeSelf)
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    //ContinueEvent   
    public void Continue()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    //ToggleGodMode
    void ToggleGodMode()
    {

        if (GodMode)
        {
            Player.GetComponent<Collider>().enabled = false;
        }
        else
        {
            Player.GetComponent<Collider>().enabled = true;
        }
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
    }
}

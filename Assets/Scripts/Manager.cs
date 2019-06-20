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

            //GodMode
            ToggleGodMode();
        }
    }


    IEnumerator Delay()
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
    void SpawnWave()
    {
        for (int i = 0; i < waveSize; i++)
        {
            SpawnEnemy();
            WaveEnemyNr++;
        }        
    }

    void WaveManagement()
    {
        if(!dontSpawnWaves)
        {
            if (WaveEnemyNr < 1 && !doCoroutineOnce)
            {
                StartCoroutine(Delay());
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

        //CALCULATE SCORE
        float scoreValue = other.GetComponent<SinusoidalMove>().scoreValue;
        FindObjectOfType<Manager>().scoreCount += scoreValue;
        //GetComponent<Manager>().scoreCount += scoreValue;

        //SHOW SCORE OVER ENEMY

        //GameObject scoreFeedback = Instantiate(scoreFeedbackPrefab, new Vector3(other.transform.position.x - 0.3f, other.transform.position.y, other.transform.position.z - 4.8f), scoreFeedbackPrefab.transform.rotation);
        GameObject scoreFeedback = Instantiate(scoreFeedbackPrefab, new Vector3(other.transform.position.x +4.73f, other.transform.position.y , other.transform.position.z-0.4f), scoreFeedbackPrefab.transform.rotation);

        scoreFeedback.GetComponent<TextMeshPro>().text = "" + other.GetComponent<SinusoidalMove>().scoreValue;


        //FindObjectOfType<SpawnEnemies>().NumberOfEnemies -= 1;

        //Spawn Particle Effect
        Instantiate(DestroyEnemyParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.Euler(0,0,0));
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
}

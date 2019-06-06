using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public GameObject DeathScreen;
    public GameObject PauseScreen;
    public GameObject scoreGUI;
    public GameObject timeGUI;
    public GameObject levelGUI;

    float time;

    [HideInInspector]
    public int amountOfProbabilities;

    [Space(20)]
    public GameObject[] enemyPrefabs;
    public int[] enemyProbabilities;
    [Space(20)]

    public int spawnsAtOnce = 3;
    public float maxSecNextEnemySpawn = 0f;
    public float minSecNextEnemySpawn = 0.2f;
    float randSecNextEnemySpawn;

    [HideInInspector]
    public float scoreCount;
    public float levelCount = 1f;
    //public int NumberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;                //Set Time to 1
        randSecNextEnemySpawn = time;      //Set Time you need to spawn the first enemy

        AmountOfProbabilities();           //Set the amount of probabilities
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            //Take Game Time
            time = time + 1 * Time.deltaTime;

            //SpawnEnemy
            if (time > randSecNextEnemySpawn)
            {
                SpawnEnemy();                                                                               //Spawn enemy
                time = 0;                                                                                   //Reset time
                randSecNextEnemySpawn = Random.Range(minSecNextEnemySpawn, maxSecNextEnemySpawn);           //Set new random spawn time 
            }

            //GUI Update
            scoreGUI.GetComponent<TextMeshProUGUI>().text = "Score: "+scoreCount;
            timeGUI.GetComponent<TextMeshProUGUI>().text = "Time: " + Time.timeSinceLevelLoad.ToString("0.00");
            levelGUI.GetComponent<TextMeshProUGUI>().text = "Level: "+levelCount;

            //PauseGame
            PauseGame();
        }
    }

    //Generate a random number to detect which type of enemy should spawn next
    int randProbability()
    {
        int randomEnemy = Random.Range(1, AmountOfProbabilities()+1);   //random number between 0 and total of all probabilities
        Debug.Log(randomEnemy);
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
        Debug.LogError("Du musst noch Wahrscheinlichkeiten einstellen, du Spast!");
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
        float spawnPosX = Random.Range(0, 11);
        Debug.Log(spawnPosX);



        GameObject instance = Instantiate(enemyPrefabs[randProbability()], new Vector3(spawnPosX - 5, 0.78f, Camera.transform.position.z + 6.7f), transform.rotation);

        //instance.GetComponent<SinusoidalMove>().moveSpeed = Random.Range(2, 15);
        //instance.GetComponent<SinusoidalMove>().frequency = Random.Range(2, 15);
    }

    void SpawnNumber()
    {
        for (int i = 0; i < spawnsAtOnce; i++)
        {
            Invoke("SpawnEnemy", 1);
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


}

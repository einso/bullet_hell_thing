using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public GameObject enemyPrefab;
    public GameObject ghostPrefab;
    public GameObject batPrefab;
    public GameObject DeathScreen;
    public GameObject PauseScreen;
    public GameObject scoreGUI;
    public GameObject timeGUI;

    float time;

    public float maxSecNextEnemySpawn = 1;
    public float minSecNextEnemySpawn = 3;
    float randSecNextEnemySpawn;

    public float scoreCount;
    //public int NumberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        randSecNextEnemySpawn = time;
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
                SpawnEnemy();
                time = 0;
                randSecNextEnemySpawn = Random.Range(minSecNextEnemySpawn, maxSecNextEnemySpawn);
            }

            //GUI Update
            scoreGUI.GetComponent<TextMeshProUGUI>().text = "Score: "+scoreCount;
            timeGUI.GetComponent<TextMeshProUGUI>().text = "Time: " + Time.timeSinceLevelLoad.ToString("0.00"); 

            //PauseGame
            PauseGame();
        }
    }

    //SpawnEnemyEvent
    void SpawnEnemy()
    {
        //NumberOfEnemies++;
        float spawnPosX = Random.Range(1, 21);
        
        GameObject instance = Instantiate(batPrefab, new Vector3(spawnPosX - 10, 0.78f, Camera.transform.position.z + 3.7f), transform.rotation);

        //instance.GetComponent<SinusoidalMove>().moveSpeed = Random.Range(2, 15);
        //instance.GetComponent<SinusoidalMove>().frequency = Random.Range(2, 15);
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

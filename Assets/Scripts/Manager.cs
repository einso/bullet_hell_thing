using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public GameObject enemyPrefab;
    public GameObject DeathScreen;
    public GameObject PauseScreen;
    float time;
    public float maxSecNextEnemySpawn = 1;
    public float minSecNextEnemySpawn = 3;
    float randSecNextEnemySpawn;
    //public int NumberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log(randSecNextEnemySpawn);
            }

            //PauseGame
            PauseGame();
        }
    }

    //SpawnEnemyEvent
    void SpawnEnemy()
    {
        //NumberOfEnemies++;
        float spawnPosX = Random.Range(1, 21);
        Instantiate(enemyPrefab, new Vector3(spawnPosX - 10, 0.78f, Camera.transform.position.z + 3.7f), transform.rotation);
    }

    //RestartEvent
    public void Restart()
    {
        SceneManager.LoadScene(0);
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

    //void ContinueEvent   
    public void Continue()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    //void QuitEvent   
    public void Quit()
    {
        Application.Quit();
    }   
    
}

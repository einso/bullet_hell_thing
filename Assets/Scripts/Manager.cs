using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject enemyPrefab;
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
        time = time + 1 * Time.deltaTime;

        if (time > randSecNextEnemySpawn)
        {
            SpawnEnemy();
            time = 0;
            randSecNextEnemySpawn = Random.Range(minSecNextEnemySpawn, maxSecNextEnemySpawn);
            Debug.Log(randSecNextEnemySpawn);
        }
        if (Input.GetKey("escape"))
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }

    void SpawnEnemy()
    {
        //NumberOfEnemies++;
        float spawnPosX = Random.Range(1, 21);
        Instantiate(enemyPrefab, new Vector3(spawnPosX - 10, 0.78f, Camera.transform.position.z + 3.7f), transform.rotation);
    }

    //void Quit()
    //{
    //    if (Input.GetKey(KeyCode.Escape))
    //    { Application.Quit();
    //        Debug.Log("QUIT!");
    //    }
    //}
}

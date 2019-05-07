using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject enemyPrefab;
    float time;
    public float SpawnNextEnemy = 2;
    //public int NumberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1 * Time.deltaTime;
        Debug.Log(time);

        if(time > SpawnNextEnemy)
        {
            SpawnEnemy();
            time = 0;
        }
    }

    void SpawnEnemy()
    {
        //NumberOfEnemies++;
        float spawnPosX = Random.Range(1,21);
        Instantiate(enemyPrefab, new Vector3(spawnPosX - 10, 0.78f, Camera.transform.position.z + 4.5f), transform.rotation);
    }
}

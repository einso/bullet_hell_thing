﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public bool Level_1;
    public bool Level_2;
    public bool Level_3;


    void Start()
    {
        //Level_1 = true;
    }

    void Update()
    {
        if(Level_1)
        {
            LoadLevel1();      
        }

        else if (Level_2)
        {
            LoadLevel2();
        }

        else if (Level_3)
        {
            LoadLevel3();   
        }
    }

    void LoadLevel1()
    {
        //GetComponent<Manager>().amountOfProbabilities = GetComponent<Manager>().AmountOfProbabilities();
        GetComponent<Manager>().enemyProbabilities = GetComponent<Level1>().enemyProbabilities;
        GetComponent<Manager>().maxSecNextEnemySpawn = GetComponent<Level1>().maxSecNextEnemySpawn;
        GetComponent<Manager>().minSecNextEnemySpawn = GetComponent<Level1>().minSecNextEnemySpawn;
    }

    void LoadLevel2()
    {
        //GetComponent<Manager>().amountOfProbabilities = GetComponent<Manager>().AmountOfProbabilities();
        GetComponent<Manager>().enemyProbabilities = GetComponent<Level2>().enemyProbabilities;
        GetComponent<Manager>().maxSecNextEnemySpawn = GetComponent<Level2>().maxSecNextEnemySpawn;
        GetComponent<Manager>().minSecNextEnemySpawn = GetComponent<Level2>().minSecNextEnemySpawn;
    }

    void LoadLevel3()
    {
        //GetComponent<Manager>().amountOfProbabilities = GetComponent<Manager>().AmountOfProbabilities();
        GetComponent<Manager>().enemyProbabilities = GetComponent<Level3>().enemyProbabilities;
        GetComponent<Manager>().maxSecNextEnemySpawn = GetComponent<Level3>().maxSecNextEnemySpawn;
        GetComponent<Manager>().minSecNextEnemySpawn = GetComponent<Level3>().minSecNextEnemySpawn;
    }
}

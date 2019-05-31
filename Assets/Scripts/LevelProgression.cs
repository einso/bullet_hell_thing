using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelProgression : MonoBehaviour
{
    Manager manager;

    void Start()
    {
        manager = GetComponent<Manager>();
    }

    void Update()
    {
        float score = manager.scoreCount;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{

    float time = 0;
    public float patternLength_1 = 5;
    public float patternLength_2 = 5;
    public float patternLength_3 = 5;

    bool Pattern_1 = true;
    bool Pattern_2 = false;
    bool Pattern_3 = false;

    void Update()
    {
        time += 1 * Time.deltaTime;

        //Pattern1
        if(Pattern_1)
        {
            if (time < patternLength_1)        //as long as time is smaller then pattern length, do something
            {
                /////////////////     
                Debug.Log("Pattern: 1");
            }
            else
            {
                time = 0;
                Pattern_1 = false;
                Pattern_2 = true;
            }
        }

        if (Pattern_2)
        {
            if (time < patternLength_2)        //as long as time is smaller then pattern length, do something
            {
                /////////////////
                Debug.Log("Pattern: 2");
            }
            else
            {
                time = 0;
                Pattern_2 = false;
                Pattern_3 = true;
            }
        }

        if (Pattern_3)
        {
            if (time < patternLength_3)        //as long as time is smaller then pattern length, do something
            {
                /////////////////
                Debug.Log("Pattern: 3");
            }
            else
            {
                time = 0;
                Pattern_3 = false;
                Pattern_1 = true;
            }
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    bool timeSlow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Time Freeze
        if (Input.GetKeyDown(KeyCode.T) && !timeSlow)
        {
            timeSlow = true;
            TimeSlow();
        }
        else if (Input.GetKeyDown(KeyCode.T) && timeSlow)
        {
            timeSlow = false;
            TimeSlow();
        }

    }

    //Time Freeze
    void TimeSlow()
    {
        if(timeSlow)
        {
            Time.timeScale = 0.25f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    float t;
    bool goDark = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goDark)
        {
            t += 1 * Time.deltaTime;
            if (t > 250) goDark = false;            
        }
        else
        {
            t -= 1 * Time.deltaTime;
            if (t < 2) goDark = true;
        }

        GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, (byte)t);
    }
}

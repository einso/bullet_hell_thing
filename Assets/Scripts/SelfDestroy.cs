using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float deathTime = 3;
    float t;

    // Update is called once per frame
    void Update()
    {
        t = t + 1 * Time.deltaTime;

        if(t > deathTime)
        {
            Destroy(this.gameObject);
        }

    }
}

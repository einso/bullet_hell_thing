using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTest : MonoBehaviour
{
    public float fireTime = .05f;
    void Start()
    {
        InvokeRepeating("Fire", fireTime, fireTime);
        
    }

 
    void Fire()
    {
        GameObject obj = NewObjectPoolerScript.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}

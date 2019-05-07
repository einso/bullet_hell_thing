using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{ 

    public bool potato;

    // Start is called before the first frame update
    void Start()
    { potato = true; }
    //void rotatopotato()
    //{
    void Update()
    {
        if (potato == true)
        {
            Debug.Log("potatooooo!");
            transform.Rotate(Vector3.up * 20 * Time.deltaTime);
            
        }
    }
    //}

    
}


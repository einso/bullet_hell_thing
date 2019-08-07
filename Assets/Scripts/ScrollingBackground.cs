using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public GameObject DeathScreen;
    public float scrollSpeed = 1;
    public float ResetPoint = 80;

    // Update is called once per frame
    void Update()
    {
        if(! DeathScreen.activeInHierarchy)
        {
            //Scrolling Background
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - scrollSpeed * Time.deltaTime);
            if (transform.position.z <= -ResetPoint) transform.position = new Vector3(transform.position.x, transform.position.y, 0); 
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 1;
    public float bonusSpeedPlayer = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            bonusSpeedPlayer = 5;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            bonusSpeedPlayer = 1;
        }
        else bonusSpeedPlayer = 1;

        //Scrolling Background
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - scrollSpeed * Time.deltaTime);
        if (transform.position.z <= -16)    transform.position = new Vector3(transform.position.x, transform.position.y, 4);

    }
}

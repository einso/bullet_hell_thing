﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - scrollSpeed * Time.deltaTime);
        if (transform.position.z <= -16)    transform.position = new Vector3(transform.position.x, transform.position.y, 4);
    }
}

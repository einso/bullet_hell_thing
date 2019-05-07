using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    void onCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Debug.Log(other);
    }
}

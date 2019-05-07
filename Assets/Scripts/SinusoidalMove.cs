using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = false;

    Vector3 pos; //,localScale

    // Use this for initialization
    void Start()
    {

        pos = transform.position;

        //localScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

        CheckWhereToFace();

        if (facingRight)
            MoveRight();
        else
            MoveLeft();
    }

    void CheckWhereToFace()
    {
        if (pos.x <= -2f)
        {
            facingRight = true;
            Debug.Log("MoveLeft");
        }
        else if (pos.x >= 4f)
        {
            facingRight = false;
            Debug.Log("MoveRight");
        }

        //if (((facingRight) && (localScale.z < 0)) || ((!facingRight) && (localScale.z > 0)))
            //localScale.z *= -1;

        //transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.forward * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.forward * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
    }


}

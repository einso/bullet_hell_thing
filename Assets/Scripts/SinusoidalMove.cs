using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMove : MonoBehaviour
{
    GameObject Camera;

    public float scoreValue = 100;

    public bool straight;
    public bool angled;

    [SerializeField]
    public float moveSpeed = 5f;

    [SerializeField]
    public float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = false;
    bool movedDown;

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

        MoveDown();

        if(movedDown)
        {
            CheckWhereToFace();

            if (facingRight)
                MoveRight();
            else
                MoveLeft();
        }
       
    }

    void CheckWhereToFace()
    {
        if (pos.x <= -5f)
        {
            facingRight = true;
        }
        else if (pos.x >= 5f)
        {
            facingRight = false;
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

    void MoveDown()
    {
        if(!movedDown)
        {
            if (straight)
            {
                if (transform.position.z > 8)
                {
                    pos += transform.right * Time.deltaTime * 3;
                    transform.position = pos + transform.forward * Mathf.Sin(Time.time * 0) * 0;
                }
                else
                {
                    movedDown = true;
                }
            }

            if (angled)
            {
                if (transform.position.z > 8)
                {
                    moveSpeed = 2;
                    pos += transform.right * Time.deltaTime * moveSpeed;
                    transform.position = pos + transform.forward * Mathf.Sin(Time.time * 0) * 0;

                    if (pos.x < 0f)
                    {
                        pos += transform.right * Time.deltaTime * moveSpeed;
                        pos += transform.forward * Time.deltaTime * moveSpeed*2;
                        transform.position = pos + transform.forward * Mathf.Sin(Time.time * 0) * 0;
                    }
                    else if (pos.x >= 0f)
                    {
                        pos += transform.right * Time.deltaTime * moveSpeed;
                        pos -= transform.forward * Time.deltaTime * moveSpeed*2;
                        transform.position = pos + transform.forward * Mathf.Sin(Time.time * 0) * 0;
                    }
                }
                else
                {
                    movedDown = true;
                    moveSpeed = 0;
                }
            }
        }




    }

}

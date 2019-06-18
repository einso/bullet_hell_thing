using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMove : MonoBehaviour
{
    GameObject Camera;

    float t;

    public float scoreValue = 100;

    [SerializeField]
    public float moveSpeed = 5f;

    [SerializeField]
    public float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = false;
    bool movedDown;

    public bool patternMovement1;
    public bool patternMovement2;
    public bool patternMovement3;
    public bool patternMovement4;

    [HideInInspector]
    public bool shootingTime;

    Vector3 pos;

    // Use this for initialization
    void Start()
    {

        pos = transform.position;

        //localScale = transform.localScale;

        int direction = Random.Range(0, 2);

        if (direction == 0)
        {
            facingRight = true;
        }
        else if (direction == 1)
        {
            facingRight = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Start Pos
        MoveDown();

        //Move Pattern
        if(patternMovement1)
        {
            if (movedDown)
            {
                CheckWhereToFace();

                if (facingRight)
                    MoveRight();
                else
                    MoveLeft();
            }
        }

        if(patternMovement2)
        {
            TakeTImeToShoot();
        }

        if(patternMovement3)
        {
            

            if (transform.position.z > 5)
            {
                shootingTime = false;
                pos += transform.right * Time.deltaTime * moveSpeed;
                transform.position = pos + transform.forward * Mathf.Sin(Time.time * 0) * 0;
            }
            else
            {
                shootingTime = true;
               /* pos += transform.right * Time.deltaTime * 1;
                transform.GetChild(0).transform.position = pos + transform.forward * Mathf.Sin(Time.time * 90f) *1f;*/
            }

          //  pos += transform.right * Time.deltaTime * 3;
          //  transform.position = pos + transform.forward * Mathf.Sin(Time.time * 1) * 2f;
        }

        if (patternMovement4)
        {

            pos += transform.right * Time.deltaTime * moveSpeed;
            transform.position = pos + transform.forward * Mathf.Sin(Time.time * 0) * 0;

            if(transform.position.z <= -7.3f)
            {
                GetComponent<EnemyLife>().health = 0;
                GetComponent<EnemyLife>().CheckHealth();
            }
        }
    }




    void CheckWhereToFace()
    {
        if (pos.x <= -4.05f)
        {
            facingRight = true;
        }
        else if (pos.x >= 4.73f)
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

    void TakeTImeToShoot()
    {


        if(pos.x <= -3f)
        {
            t += 1 * Time.deltaTime;
            shootingTime = true;

            if (t > 3)
            {
                MoveRight();
                facingRight = true;
                shootingTime = false;
            }
        }
        else if(pos.x >= 3f)
        {
            t += 1 * Time.deltaTime;
            shootingTime = true;

            if (t > 3)
            {
                MoveLeft();
                facingRight = false;
                shootingTime = false;
            }
        }
        else
        {
            CheckWhereToFace();

            if (facingRight)
                MoveRight();
            else
                MoveLeft();
            t = 0;
        }
    }

    void MoveDown()
    {
        if (!movedDown)
        {

            if (transform.position.z > 12)
            {
                pos += transform.right * Time.deltaTime * moveSpeed;
                transform.position = pos + transform.forward * Mathf.Sin(Time.time * 0) * 0;
            }
            else
            {
                movedDown = true;
            }
            
        }
    }




}



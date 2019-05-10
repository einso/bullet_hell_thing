using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Manager;
    public float playerMoveSpeed = 15;
    public float playerRotationSpeed = 15;
    float shipBoundary = 0.35f;

    //Screenbounds
    public Camera Camera; 
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        screenBounds = Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.transform.position.y));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.z; //extents = size of height / 2

        Debug.Log(objectHeight);
    }

    private void Update()
    {

        //Rotate Player
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Rotation") * playerRotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(90, 0, 0);
        transform.rotation = rot;

        //Move Player
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(Input.GetAxisRaw("Horizontal") * playerMoveSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * playerMoveSpeed * Time.deltaTime, 0);
        pos += rot * posChange;
        transform.position = pos;

    }

}

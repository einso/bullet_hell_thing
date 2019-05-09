using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusBullet : MonoBehaviour
{

    [SerializeField]
    public float moveSpeed = 7f;

    [SerializeField]
    public float frequency = 8f;

    [SerializeField]
    float magnitude = 0.5f;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        /*moveSpeed = Random.Range(4, 9);
        frequency = Random.Range(5, 15);
        magnitude = Random.Range(0.25f, 0.75f);*/
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.forward * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.name);
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<Manager>().PlayerDeath();
        }
        if (other.gameObject.tag == "EndWall")
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }
}

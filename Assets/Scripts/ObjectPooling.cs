using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public int pooledAmount = 100;
    public GameObject Bullet;
    public List<GameObject> pooledObjects;
    int bulletNr = 0;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < 100; i++)
        {
            GameObject b = Instantiate(Bullet);
            b.SetActive(false);
            pooledObjects.Add(b);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiatePool(Vector3 pos, Quaternion rot)
    {
        pooledObjects[bulletNr].transform.position = pos;
        pooledObjects[bulletNr].transform.rotation = rot;
        pooledObjects[bulletNr].SetActive(true);
        bulletNr++;
        
    }
}

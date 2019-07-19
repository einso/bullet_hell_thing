using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolNoobBullets : MonoBehaviour
{

    //Pooling
    public GameObject NoobBulletPrefab;
    public GameObject EnemyBullets;
    public int pooledAmount = 200;
    public List<GameObject> pooledObjects;
    [HideInInspector]
    public int bulletNr = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Pooling
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject b = Instantiate(NoobBulletPrefab);
            b.SetActive(false);
            b.transform.parent = EnemyBullets.transform;
            pooledObjects.Add(b);
        }
    }

    public void InstantiateNoobPool(Vector3 pos, Quaternion rot)
    {
        pooledObjects[bulletNr].transform.position = pos;
        pooledObjects[bulletNr].transform.rotation = rot;
        pooledObjects[bulletNr].SetActive(true);
        bulletNr++;
        if (bulletNr > pooledAmount - 1) bulletNr = 0;

    }
}

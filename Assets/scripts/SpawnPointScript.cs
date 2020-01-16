using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//using Random = System.Random;

public class SpawnPointScript : MonoBehaviour
{
    public List<Vector3> spawnPoints = new List<Vector3>();

    public GameObject leadBullet;
    public GameObject silverBullet;
    public GameObject lantern;
    public GameObject key;

    public GameObject barrier;

    public int numberOfKeys = 0;


    // Start is called before the first frame update
    void Start()
    {
        initSpawnPoints();
        determineItemSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfKeys == 3)
        {
            Destroy(barrier);
        }
    }

    private void initSpawnPoints()
    {
        spawnPoints.Add(new Vector3(-81, 31, 0));
        spawnPoints.Add(new Vector3(19, 48, 0));
        spawnPoints.Add(new Vector3(30, 14, 0));
        spawnPoints.Add(new Vector3(81, 22, 0));
        spawnPoints.Add(new Vector3(-104, 36, 0));
        spawnPoints.Add(new Vector3(-167, 43, 0));
        spawnPoints.Add(new Vector3(-179, 128, 0));
        
        /*spawnPoints[0] = new Vector3(-81, 31, 0);
        spawnPoints[1] = new Vector3(19, 48, 0);
        spawnPoints[2] = new Vector3(30, 14, 0);
        spawnPoints[3] = new Vector3(81, 22, 0);
        spawnPoints[4] = new Vector3(-104, 36, 0);
        spawnPoints[5] = new Vector3(-167, 43, 0);
        spawnPoints[6] = new Vector3(-179, 128, 0);*/
    }

    private void determineItemSpawn()
    {
        int keyAmount = 0;
        bool lanternSpawned = false;
        int item = 0;
        
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints.Count - i <= 3 - keyAmount && keyAmount < 3)
            {
                item = 0;
            }
            else
            {
                item = Random.Range(1, 3);
            }
            if (item == 0 && keyAmount < 3)
            {
                // key
                Instantiate(key, spawnPoints[i], transform.rotation);
                keyAmount++;
                numberOfKeys++;
            } else if (item == 1 && !lanternSpawned)
            {
                // lantern
                Instantiate(lantern, spawnPoints[i], transform.rotation);
                lanternSpawned = true;
            }
            else if (item == 2) 
            {
                // silver bullet
                Instantiate(this.silverBullet, spawnPoints[i], transform.rotation);
            }
            else
            {
                // lead bullet
                Instantiate(leadBullet, spawnPoints[i], transform.rotation);
            }
        }
    }
    
}

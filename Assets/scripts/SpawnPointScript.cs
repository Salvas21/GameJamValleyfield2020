using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    
    //public Transform[] spawnPoints = new Transform[5];
    public List<Vector3> spawnPoints = new List<Vector3>();
    public List<GameObject> itemsToAdd = new List<GameObject>();

    public GameObject leadBullet;
    public GameObject silverBullet;
    public GameObject lantern;
    public GameObject key;


    // Start is called before the first frame update
    void Start()
    {
        initSpawnPoints();
        determineItemSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initSpawnPoints()
    {
        spawnPoints[0] = new Vector3(-82, 31, 0);
        spawnPoints[1] = new Vector3(19, 48, 0);
        spawnPoints[2] = new Vector3(30, 14, 0);
        spawnPoints[3] = new Vector3(81, 22, 0);
        
    }

    private void determineItemSpawn()
    {
        int keyAmount = 0;
        bool lanternSpawned = false;
        int item = 0;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            item = 1;
            if (item == 0 && keyAmount < 3)
            {
                // key
                itemsToAdd.Add(Instantiate(this.key, spawnPoints[i], transform.rotation));
                spawnPoints.RemoveAt(i);
            } else if (item == 1 && !lanternSpawned)
            {
                // lantern
                //itemsToAdd.Add(Instantiate(this.lantern, spawnPoints[i], transform.rotation));
                Instantiate(lantern, spawnPoints[i], transform.rotation);
                spawnPoints.RemoveAt(i);
                lanternSpawned = true;
            }
            else if (item == 2) 
            {
                // silver bullet
                itemsToAdd.Add(Instantiate(this.silverBullet, spawnPoints[i], transform.rotation));
                spawnPoints.RemoveAt(i);
            }
            else
            {
                // lead bullet
                //itemsToAdd.Add(Instantiate(this.leadBullet, spawnPoints[i], transform.rotation));
                Instantiate(leadBullet, spawnPoints[i], transform.rotation);
                spawnPoints.RemoveAt(i);
            }
        }
    }
    
}

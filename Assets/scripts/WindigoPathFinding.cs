﻿using System;
using Pathfinding;
using UnityEngine;

public class WindigoPathFinding : MonoBehaviour
{
    public float maxDistance;
    public AIDestinationSetter destination;
    public float timeToLosePlayer;

    private GameObject poiTargetObject;

    private GameObject player;
    private Transform currentPoi = null;
    private readonly Vector2[] pois = { new Vector2(-82, 30), new Vector2(29, 13), new Vector2(80, 21), new Vector2(18, 47), new Vector2(-5, 137)};
    private float timeLostPlayer;

    // Start is called before the first frame update
    void Start()
    {
        poiTargetObject = new GameObject("Poi");
        timeLostPlayer = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoi != null)
            Debug.Log(currentPoi.position);

        player = GameObject.Find("Player");
        if(DistanceToOther(player) < maxDistance)
        {
            destination.target = player.transform;
            timeLostPlayer = Time.realtimeSinceStartup;
            //Debug.Log("Player is close");
        } else {
            //Debug.Log("Player is far");
            if (Time.realtimeSinceStartup - timeLostPlayer > timeToLosePlayer)
            {
                //Debug.Log("Lost player time");
                if (currentPoi == null)
                {
                    Debug.Log("New poi: ");
                    currentPoi = RandomPoi();
                    Debug.Log(currentPoi.position);
                    destination.target = currentPoi;
                } else if(ArrivedAtPoi(currentPoi)) {
                    //Debug.Log("Arrived at poi");
                    currentPoi = null;
                } else {
                    //Debug.Log("Same poi");
                    destination.target = currentPoi;
                }
            } else {
                //Debug.Log("Buffer cant move");
                destination.target = null;
            }
        }
    }

    private Transform RandomPoi()
    {
        System.Random rnd = new System.Random();
        Vector2 vector = pois[rnd.Next(pois.Length - 1)];
        poiTargetObject.transform.position = new Vector3(vector.x, vector.y, 0);
        Transform tempTrans = poiTargetObject.transform;
        return tempTrans;
    }

    private bool ArrivedAtPoi(Transform poi)
    {
        return DistanceToOther(poi) < maxDistance;
    }

    private float DistanceToOther(GameObject other)
    {
        return Mathf.Pow(((this.transform.position.x - other.transform.position.x)), 2) + Mathf.Pow((this.transform.position.y - other.transform.position.y), 2);
    }

    private float DistanceToOther(Transform other)
    {
        return Mathf.Pow(((this.transform.position.x - other.position.x)), 2) + Mathf.Pow((this.transform.position.y - other.position.y), 2);
    }
}
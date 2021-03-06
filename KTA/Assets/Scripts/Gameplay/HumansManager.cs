﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumansManager : MonoBehaviour
{
    #region Fields
    public LayerMask spaceOccupied;
    public GameObject[] humansPrefabs;
    public Transform[] spawnPoints;
    public float spawnTime = 2;
    int minHumans = 1;
    int maxHumans = 3;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        SpawnHuman();
        spaceOccupied = LayerMask.GetMask(new string[] { "Player", "Targets" });
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] humans = GameObject.FindGameObjectsWithTag("Human");
        if (humans.Length <= minHumans)
        {
            SpawnHuman();
        }
    }

    public void SpawnHuman()
    {
        int index = Random.Range(0, spawnPoints.Length);
        int indexEne = Random.Range(0, humansPrefabs.Length);
        Collider[] colliders = Physics.OverlapBox(spawnPoints[index].position, transform.localScale * 2, Quaternion.identity, spaceOccupied);
        if (colliders.Length == 0)
        {
            Instantiate(humansPrefabs[indexEne], spawnPoints[index].position, spawnPoints[index].rotation);
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireCube(spawnPoints[0].position, transform.localScale * 2);
    }
}

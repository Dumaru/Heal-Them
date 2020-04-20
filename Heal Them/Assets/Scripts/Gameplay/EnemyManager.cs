using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public LayerMask spaceOccupied;
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public int minEnemies = 3;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        spaceOccupied = LayerMask.GetMask(new string[] { "Player", "Targets" });
    }


    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length < minEnemies)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        foreach (Transform spawnPo in spawnPoints)
        {
            Collider[] colliders = Physics.OverlapBox(spawnPo.position, transform.localScale * 2, Quaternion.identity, spaceOccupied);
            if (colliders.Length == 0)
            {
                Instantiate(enemyPrefabs[index], spawnPo.position, spawnPo.rotation);
            }
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

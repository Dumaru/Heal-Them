using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePointsSpawner : MonoBehaviour
{
    public float spawnTime;
    public Transform[] spawnPoints;
    public GameObject[] rechargePointPrefabs;
    private GameObject[] spawned;
    bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRechargePoints", 0);
    }

    private void SpawnRechargePoints()
    {
        int indexRecharge = Random.Range(0, rechargePointPrefabs.Length);
        foreach (Transform transformRecharge in spawnPoints)
        {
            Instantiate(rechargePointPrefabs[indexRecharge], transformRecharge.position, transformRecharge.rotation);
        }
        spawning = false;
    }
    // Update is called once per frame
    void Update()
    {
        RechargePoint[] rechargePoints = GameObject.FindObjectsOfType<RechargePoint>();
        if (rechargePoints.Length <= 0 && !spawning)
        {
            spawning = true;
            Invoke("SpawnRechargePoints", spawnTime);
        }
    }


}

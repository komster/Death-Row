using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_EnemySpawner : MonoBehaviour {

    public GameObject Enemy1;
    public GameObject Enemy2;
    public CS_Gamemanager cSGM;
    public List<Transform> spawnPoints = new List<Transform>();




    private GameObject chosenEnemyType;
    private Transform chosenSpawnPoint;
    private int enemySpawnChance;
    private int randomSpawn;
    private int amountOfSpawnPoints;

    void Start ()
    {
        cSGM = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
       
        EnemySpawnChance();
        GetSpawnPoints();
        WhatEnemy();
        SpawnEnemies();




        
        
		
	}

    private void EnemySpawnChance()
    {
        if (cSGM.timeInGame > 300f)
        {
            enemySpawnChance = Random.Range(1, 10);
        }
        else
        {
            enemySpawnChance = Random.Range(1, 20);
        }
    }

    private void GetSpawnPoints()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.tag == "SpawnPoint")
            {
                spawnPoints.Add(child);
                amountOfSpawnPoints++;
            }
        }

        if (spawnPoints.Count > 1)
        {
            randomSpawn = Random.Range(0, amountOfSpawnPoints-1);
        }
        else
        {
            randomSpawn = 0;
        }
        chosenSpawnPoint = spawnPoints[randomSpawn];
       
    }
    private void WhatEnemy()
    {
        switch (Random.Range(1,2))
        {
            case (1):
                chosenEnemyType = Enemy1;
                break;
            case (2):
                chosenEnemyType = Enemy2;
                break;
        }
    }
    private void SpawnEnemies()
    {
        if (enemySpawnChance == 2 || enemySpawnChance == 4 || enemySpawnChance == 6 || enemySpawnChance == 8 || enemySpawnChance == 10)
        {
            Debug.Log("enemy spawned");
            Instantiate(chosenEnemyType, chosenSpawnPoint.transform.position, Quaternion.Euler(0, 0, Random.Range(-360, 360)));
        }
    }

}

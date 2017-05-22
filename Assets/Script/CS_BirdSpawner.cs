using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BirdSpawner : MonoBehaviour
{

    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject bird;

    private int birdSpawnChance;
    private int randomSpawn;
    private int amountOfSpawnPoints;


    // Use this for initialization
    void Start()
    {
        GetSpawnPoints();
      
    }


    private void GetSpawnPoints()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (child.tag == "Bird")
            {
                spawnPoints.Add(child);
                amountOfSpawnPoints++;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CannonBallEnemy" || other.tag == "CannonBallPlayer")
        {
            RandomizeSpawn();
            Debug.Log(birdSpawnChance);

        }

    }
    private void RandomizeSpawn()
    {
        birdSpawnChance = Random.Range(1, 5);
        randomSpawn = Random.Range(0, amountOfSpawnPoints-1);
        if (birdSpawnChance > 2)
        {
            Instantiate(bird, spawnPoints[randomSpawn].transform.position, Quaternion.identity);
        }
    }
   
}
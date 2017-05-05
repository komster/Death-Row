using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Stages : MonoBehaviour {

    private bool travleStage = false;
    private bool battleStage = false;

    private int wave = 0;

    private bool spawnIn = false;

    public GameObject player;
    public GameObject meduimEnemyBattel;
    public GameObject largeEnemeyBattel;
    public GameObject meduimEnemyTravel;
    public GameObject largeEnemeyTravel;
    public GameObject clouds;
    public GameObject[] arenas;

    private GameObject tempClouds;
    private GameObject tempArena;
    private GameObject tempEnemy;



    void Start () {
        CS_Notify.Register(this, "ChangeStage");
        ChangeStage();
	}
	
	void Update () {
        if (tempClouds != null)
        {
            if (tempClouds.transform.position.x > player.transform.position.x)
            {
                if (spawnIn == true)
                {
                    if (battleStage == true)
                    {
                        CS_Notify.Send(this, "TurnOffWorldSpawn");
                        CS_Notify.Send(this, "ChangeToArenaCamera");
                        tempClouds.transform.position = new Vector3(tempClouds.transform.position.x,3,tempClouds.transform.position.z);
                        arenas[wave].transform.position = new Vector3(0, 0, 0);
                        tempArena = Instantiate<GameObject>(arenas[wave]);
                        Quaternion playerRotation = player.transform.rotation;
                        playerRotation.z = -1;
                        player.transform.rotation = playerRotation;
                        player.transform.position = new Vector3(-10, 3, 0);
                        spawnIn = false;
                        Destroy(tempEnemy);
                        if (wave == 0)
                        {
                            tempEnemy = Instantiate<GameObject>(meduimEnemyBattel);
                            tempEnemy.transform.position = new Vector3(40,3,0);
                        }
                        if (wave == 1)
                        {
                            tempEnemy = Instantiate<GameObject>(largeEnemeyBattel);
                            tempEnemy.transform.position = new Vector3(40, 3, 0);
                        }
                    }

                    if (travleStage == true)
                    {
                        CS_Notify.Send(this,"MovePlayer");
                        CS_Notify.Send(this, "TurnOnWorldSpawn");
                        CS_Notify.Send(this, "ChangeToTravelCamera");
                        player.transform.rotation = new Quaternion(0,0,0,0);
                        spawnIn = false;
                        Destroy(tempEnemy.gameObject);
                        Destroy(tempArena.gameObject);
                        if (wave == 1)
                        {
                            tempEnemy = Instantiate(largeEnemeyTravel, new Vector3(player.transform.position.x, player.transform.position.y - 30, player.transform.position.z), new Quaternion(0, 0, 0, 0));;
                        }
                    }

                }

            }
            if (tempClouds.transform.position.x > player.transform.position.x + 150)
            {
                Destroy(tempClouds);
                if (battleStage == true)
                {
                    CS_Enemy_Battel script = tempEnemy.GetComponent<CS_Enemy_Battel>();
                    script.enabled = true;
                }
                if (travleStage == true)
                {
                    CS_Notify.Send(this, "EnemyBoatStart");
                }

            }
        }
    }

    public void ChangeStage()
    {
        if (battleStage == true)
        {
            spawnIn = true;
            clouds.transform.position = new Vector3(player.transform.position.x - 100, player.transform.position.y, player.transform.position.z);
            tempClouds = Instantiate<GameObject>(clouds);
            Rigidbody2D tempRb = tempClouds.GetComponent<Rigidbody2D>();
            tempRb.velocity = transform.right * 30;
            travleStage = true;
            battleStage = false;
            wave++;
        }
        else if (travleStage == true)
        {
            spawnIn = true;
            clouds.transform.position = new Vector3(player.transform.position.x - 100, player.transform.position.y, player.transform.position.z);
            tempClouds = Instantiate<GameObject>(clouds);
            Rigidbody2D tempRb = tempClouds.GetComponent<Rigidbody2D>();
            tempRb.velocity = transform.right * 30;
            battleStage = true;
            travleStage = false;
        }
        else if (battleStage == false && travleStage == false)
        {
            CS_Notify.Send(this, "TurnOnWorldSpawn");
            if (wave == 0)
            {
                tempEnemy = Instantiate(meduimEnemyTravel, new Vector3(player.transform.position.x, player.transform.position.y - 20, player.transform.position.z), new Quaternion(0, 0, 0, 0));
            }

            travleStage = true;
        }
    }
}

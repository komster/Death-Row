using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_Stages : MonoBehaviour {
    private bool travleStage = false;
    public bool battleStage = false;
    
    private int wave = 0;

    private bool spawnIn = false;

    public GameObject player;
    public GameObject meduimEnemyBattel;
    public GameObject largeEnemeyBattel;
    public GameObject meduimEnemyTravel;
    public GameObject largeEnemeyTravel;
    public GameObject clouds;
    public GameObject[] arenas;
    public GameObject progressbar;

    private GameObject tempClouds;
    private GameObject tempArena;
    private GameObject tempEnemy;

    private CS_Player_Movment playerScript;

    public Transform progressPlayer;
    public Transform progressEnemy;

    private float lastPlayerY;
    private float lastEnemyY;



    void Start () {
        CS_Notify.Register(this, "ChangeStage");
        playerScript = player.GetComponent<CS_Player_Movment>();
        ChangeStage();
        progressPlayer.localPosition = new Vector3(progressPlayer.localPosition.x, -300, progressPlayer.localPosition.z);
        progressEnemy.localPosition = new Vector3(progressEnemy.localPosition.x, -300, progressEnemy.localPosition.z);
        lastPlayerY = player.transform.position.y;
        lastEnemyY = tempEnemy.transform.position.y;
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
                        if (tempEnemy != null)
                        {
                            Destroy(tempEnemy.gameObject);
                        }

                        Destroy(tempArena.gameObject);
                        if (wave == 1)
                        {
                            tempEnemy = Instantiate(largeEnemeyTravel, new Vector3(player.transform.position.x, player.transform.position.y - 30, player.transform.position.z), new Quaternion(0, 0, 0, 0));;
                            lastPlayerY = player.transform.position.z;
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
                    playerScript.enabled = true;
                }
                if (travleStage == true)
                {
                    CS_Notify.Send(this, "EnemyBoatStart");
                    playerScript.enabled = true;
                }

            }
        }

        float playerYPos = player.transform.position.y;
        if (playerYPos - lastPlayerY >= 1)
        {
            progressPlayer.localPosition = new Vector3(progressPlayer.localPosition.x, progressPlayer.localPosition.y + 1f, progressPlayer.localPosition.z);
            lastPlayerY = player.transform.position.y;
        }

        if (tempEnemy != null)
        {
            float enemyYPos = tempEnemy.transform.position.y;
            if (enemyYPos - lastEnemyY >= 1)
            {
                progressEnemy.localPosition = new Vector3(progressEnemy.localPosition.x, progressEnemy.localPosition.y + 0.8f, progressEnemy.localPosition.z);
                lastEnemyY = tempEnemy.transform.position.y;
            }
        }



    }

    public void ChangeStage()
    {
        if (battleStage == true)
        {
            CS_Notify.Send(this, "StopMoving");
            spawnIn = true;
            clouds.transform.position = new Vector3(player.transform.position.x - 100, player.transform.position.y, player.transform.position.z - 3);
            tempClouds = Instantiate<GameObject>(clouds);
            Rigidbody2D tempRb = tempClouds.GetComponent<Rigidbody2D>();
            tempRb.velocity = transform.right * 30;
            travleStage = true;
            battleStage = false;
            progressbar.SetActive(true);
            wave++;
            playerScript.enabled = false;
        }
        else if (travleStage == true)
        {
            CS_Notify.Send(this, "StopMoving");
            spawnIn = true;
            clouds.transform.position = new Vector3(player.transform.position.x - 100, player.transform.position.y, player.transform.position.z - 3);
            tempClouds = Instantiate<GameObject>(clouds);
            Rigidbody2D tempRb = tempClouds.GetComponent<Rigidbody2D>();
            tempRb.velocity = transform.right * 30;
            battleStage = true;
            travleStage = false;
            progressbar.SetActive(false);
            playerScript.enabled = false;
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

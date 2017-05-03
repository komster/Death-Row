using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BattelStage : MonoBehaviour {

    private bool battelStageOn = false;
    public GameObject enemy;
    public GameObject player;
    public GameObject arena;
    public GameObject fog;

    private GameObject tempFog;

    CS_Enemy_TravelStage enemyScript;
    CS_Enemy_Battel enemyBattelScript;
    CapsuleCollider2D enemyCollider;
    CS_Player_Movment playerMovment;
    CS_Player_Cannons playerCannons;

    private bool spawnIn = false;


    void Start () {
        CS_Notify.Register(this,"BattelStageOn");
        CS_Notify.Register(this, "BattelStageOff");
        CS_Notify.Register(this, "StartFight");
        enemyScript = enemy.GetComponent<CS_Enemy_TravelStage>();
        enemyBattelScript = enemy.GetComponent<CS_Enemy_Battel>();
        enemyCollider = enemy.GetComponent<CapsuleCollider2D>();
        playerMovment = player.GetComponent<CS_Player_Movment>();
        playerCannons = player.GetComponent<CS_Player_Cannons>();
    }
	

	void Update () {
        if (tempFog != null)
        {
            if (tempFog.transform.position.x > player.transform.position.x)
            {
                if (spawnIn == false)
                {
                    CS_Notify.Send(this, "TravelStageOff");
                    arena.transform.position = new Vector3(0, 0, 0);
                    Instantiate<GameObject>(arena);
                    player.transform.rotation = new Quaternion(0, 0, 90, 0);
                    player.transform.position = new Vector3(40, 0, 0);
                    spawnIn = true;
                }

            }
            if (tempFog.transform.position.x > player.transform.position.x + 100)
            {
                StartFight();
                Destroy(tempFog);
            }
        }  
    }

    public void BattelStageOn()
    {
        spawnIn = false;
        battelStageOn = true;
        CS_Notify.Send(this, "ChangeToArenaCamera");
        enemyCollider.enabled = true;
        playerMovment.enabled = false;
        playerCannons.enabled = false;
        enemyScript.enabled = false;
        fog.transform.position = new Vector3(player.transform.position.x - 100, player.transform.position.y + 30,player.transform.position.z);
        tempFog = Instantiate<GameObject>(fog);
        Rigidbody2D tempRb = tempFog.GetComponent<Rigidbody2D>();
        tempRb.velocity = transform.right *30;
        


    }
    public void BattelStageOff()
    {
        battelStageOn = false;

    }

    public void StartFight()
    {
        playerMovment.enabled = true;
        playerCannons.enabled = true;
        enemyBattelScript.enabled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy_TravelStage : MonoBehaviour {

    public GameObject player;
    public GameObject arena;

    public float movmentSpeed;

    private float timer = 5;

    private Rigidbody2D rb;

    private bool gameStarted = false;

	void Start () {
        CS_Notify.Register(this, "StartGame");
    }
	
	void Update () {
        if (gameStarted == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 5);
        }

        if (gameStarted == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * movmentSpeed);

            if (timer <= 0)
            {
                movmentSpeed += 0.0005f;
            }

            transform.position = new Vector3(player.transform.position.x, transform.position.y, -1);

            timer -= Time.deltaTime;

            if (player.transform.position.y < transform.position.y + 2)
            {
                CS_Notify.Send(this, "ChangeToArenaCamera");
                CS_Notify.Send(this, "TurnOff");
                CapsuleCollider2D enemyCollider = GetComponent<CapsuleCollider2D>();
                enemyCollider.enabled = true;
                CS_Enemy_TravelStage enemyScript = GetComponent<CS_Enemy_TravelStage>();
                CS_Enemy_Battel enemyBattelScript = GetComponent<CS_Enemy_Battel>();
                enemyBattelScript.on = true;
                enemyBattelScript.enabled = true;
                enemyScript.enabled = false;
                arena.transform.position = new Vector3(0,0,0);
                Instantiate<GameObject>(arena);
            }
        }
        
	}

    public void StartGame()
    {
        gameStarted = true;
    }
}

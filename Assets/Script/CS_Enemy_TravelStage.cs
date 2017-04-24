using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy_TravelStage : MonoBehaviour {

    public GameObject player;
    public Camera main;

    public float movmentSpeed;

    private float timer = 5;

    private Rigidbody2D rb;

	void Start () {
	}
	
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * movmentSpeed);

        if (timer <= 0)
        {
            movmentSpeed += 0.001f;
        }

        transform.position = new Vector3(player.transform.position.x, transform.position.y,-1);

        timer -= Time.deltaTime;

        if (player.transform.position.y < transform.position.y + 2) 
        {
            CS_Camera_Movment cameraScript = main.GetComponent<CS_Camera_Movment>();
            cameraScript.rb.Sleep();
            cameraScript.enabled = false;        
            CS_Player_Movment playerMovmentScript = player.GetComponent<CS_Player_Movment>();
            playerMovmentScript.rb.Sleep();
            playerMovmentScript.enabled = false;
            CS_Player_Cannons playerCannonScript = player.GetComponent<CS_Player_Cannons>();
            playerCannonScript.enabled = false;
            CS_Enemy_TravelStage enemyScript = GetComponent<CS_Enemy_TravelStage>();
            enemyScript.enabled = false;
        }
	}
}

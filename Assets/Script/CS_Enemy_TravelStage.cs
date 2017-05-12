using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy_TravelStage : MonoBehaviour {

    public Transform player;
    public float movmentSpeed;

    private float timer = 5;
    private Rigidbody2D rb;

    private bool gameStarted = false;

	void Start () {
        CS_Notify.Register(this, "EnemyBoatStart");
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	void Update () {
        if (gameStarted == false)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 5);
        }

        if (gameStarted == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * movmentSpeed);

            if (timer <= 0)
            {
                movmentSpeed += 0.001f;
            }

            transform.position = new Vector3(player.transform.position.x, transform.position.y, -1);

            timer -= Time.deltaTime;

            if (player.position.y < transform.position.y + 2)
            {
                CS_Notify.Send(this, "ChangeStage");
                CS_Notify.Unregister(this, "EnemyBoatStart");
                gameStarted = false;
            }
        }
        
	}

    public void EnemyBoatStart()
    {
        gameStarted = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Movment : MonoBehaviour {

    public Rigidbody2D rb;
    public float movSpeed = 3.0f;
    public float timerStopTime = 2f;

    private float timer = 2f;
    private float latestControllerP1Position;
    private float latestControllerP2Position;


    void Start () {
	}
	
	void Update () {

        if (Input.GetAxis("ControllerP1") == 1 || Input.GetAxis("ControllerP1") == -1)
        {
            if (Input.GetAxis("ControllerP1") != latestControllerP1Position)
            {
                latestControllerP1Position = Input.GetAxis("ControllerP1");
                transform.Rotate(Vector3.forward, 10, 0);
                rb.velocity = transform.up * movSpeed;
                timer = timerStopTime;
            }
            
        }
        if (Input.GetAxis("ControllerP2") == 1 || Input.GetAxis("ControllerP2") == -1)
        {
            if (Input.GetAxis("ControllerP2") != latestControllerP2Position)
            {
                latestControllerP2Position = Input.GetAxis("ControllerP2");
                transform.Rotate(Vector3.back, 10, 0);
                rb.velocity = transform.up * movSpeed;
                timer = timerStopTime;
            }
           
        }
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer <= 0)
        {
            rb.velocity = (new Vector2(0, 0));
        }
    }
}

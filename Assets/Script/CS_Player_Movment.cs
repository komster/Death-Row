using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Movment : MonoBehaviour {

    public Rigidbody2D rb;
    public float movSpeed = 3.0f;

    private float latestControllerP1Position;
    private float latestControllerP2Position;

    private bool rightOar;
    private bool leftOar;

    private float rightTimer = 0.5f;
    private float leftTimer = 1f;




    void Start () {
	}
	
	void Update () {

        if (Input.GetAxis("ControllerP1") >= 0.5 || Input.GetAxis("ControllerP1") <= -0.5)
        {
            if (Input.GetAxis("ControllerP1") != latestControllerP1Position)
            {
                latestControllerP1Position = Input.GetAxis("ControllerP1");
                leftOar = true;
                leftTimer = 0.5f;
                rb.drag = 0;
                if (leftOar == true && rightOar == false)
                {
                    transform.Rotate(Vector3.forward, 5, 0);
                    rb.velocity = transform.up * movSpeed;
                    Debug.Log("velocity");
                }
            }
            
        }
        if (Input.GetAxis("ControllerP2") >= 0.5 || Input.GetAxis("ControllerP2") <= -0.5)
        {
            if (Input.GetAxis("ControllerP2") != latestControllerP2Position)
            {
                latestControllerP2Position = Input.GetAxis("ControllerP2");
                rightOar = true;
                rightTimer = 0.5f;
                rb.drag = 0;
                if (leftOar == false && rightOar == true)
                {
                    transform.Rotate(Vector3.back, 5, 0);
                    rb.velocity = transform.up * movSpeed;
                    Debug.Log("velocity");
                }
            }
           
        }
        if (leftOar == true && rightOar == true)
        {
            transform.Rotate(0, 0, 0);
            rb.velocity = transform.up * movSpeed;
            Debug.Log("velocity");
        }

        rb.drag = 0.5f;
        rightTimer -= Time.deltaTime;
        leftTimer -= Time.deltaTime;

        if (rightTimer <= 0)
        {
            rightOar = false;
        }
        if (leftTimer <= 0)
        {
            leftOar = false;
        }

        Debug.Log("left " + leftOar);
        Debug.Log("right " + rightOar);
    }
}

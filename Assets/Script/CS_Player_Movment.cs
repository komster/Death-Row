using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Movment : MonoBehaviour {

    public Rigidbody2D rb;
    public float movSpeed = 3.0f;

    private bool latestControllerP1;
    private bool latestControllerP2;

    private bool rightOar;
    private bool leftOar;

    private float rightTimer = 0.5f;
    private float leftTimer = 1f;




    void Start () {
	}
	
	void Update () {

        if (Input.GetAxis("ControllerP1") >= 0.5 || Input.GetAxis("ControllerP1") <= -0.5)
        {
            if (Input.GetAxis("ControllerP1") >= 0.5 && latestControllerP1 == true)
            {
                latestControllerP1 = false;
                leftOar = true;
                leftTimer = 0.5f;
                rb.drag = 0;
                if (leftOar == true && rightOar == false)
                {
                    transform.Rotate(Vector3.forward, 5, 0);
                    rb.velocity = transform.up * movSpeed;
                }
            }
            if (Input.GetAxis("ControllerP1") <= -0.5 && latestControllerP1 == false)
            {
                latestControllerP1 = true;
                leftOar = true;
                leftTimer = 0.5f;
                rb.drag = 0;
                if (leftOar == true && rightOar == false)
                {
                    transform.Rotate(Vector3.forward, 5, 0);
                    rb.velocity = transform.up * movSpeed;
                }
            }

        }
        if (Input.GetAxis("ControllerP2") >= 0.5 || Input.GetAxis("ControllerP2") <= -0.5)
        {
            if (Input.GetAxis("ControllerP2") >= 0.5 && latestControllerP2 == true)
            {
                latestControllerP2 = false;
                rightOar = true;
                rightTimer = 0.5f;
                rb.drag = 0;
                if (leftOar == false && rightOar == true)
                {
                    transform.Rotate(Vector3.back, 5, 0);
                    rb.velocity = transform.up * movSpeed;
                }
            }
            if (Input.GetAxis("ControllerP2") <= -0.5 && latestControllerP2 == false)
            {
                latestControllerP2 = true;
                rightOar = true;
                rightTimer = 0.5f;
                rb.drag = 0;
                if (leftOar == false && rightOar == true)
                {
                    transform.Rotate(Vector3.back, 5, 0);
                    rb.velocity = transform.up * movSpeed;
                }
            }

        }
        if (leftOar == true && rightOar == true)
        {
            transform.Rotate(0, 0, 0);
            rb.velocity = transform.up * movSpeed;
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
    }
}

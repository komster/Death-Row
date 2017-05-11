using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Movment : MonoBehaviour {

    public CS_OarLeftScript leftOarScript;
    public CS_OarRightScript rightOarScript;

    public Rigidbody2D rb;
    public float movSpeed = 6.0f;

    private bool latestControllerP1;
    private bool latestControllerP2;

    private bool rightOar;
    private bool leftOar;

    private float rightTimer = 0.5f;
    private float leftTimer = 0.5f;

    private bool gameStarted = false;

    void Start ()
    {

        leftOarScript = GameObject.Find("LeftOars").GetComponent<CS_OarLeftScript>();
        rightOarScript = GameObject.Find("RightOars").GetComponent<CS_OarRightScript>();

        CS_Notify.Register(this, "StartGame");
        CS_Notify.Register(this, "MovementUpgrade");
    }
	
	void Update () {

        if (gameStarted == true)
        {
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
                        transform.Rotate(Vector3.forward, 8, 0);
                        rb.velocity = transform.up * movSpeed;
                    }
                    leftOarScript.upIsTheTarget = true;
                }
                if (Input.GetAxis("ControllerP1") <= -0.5 && latestControllerP1 == false)
                {
                    latestControllerP1 = true;
                    leftOar = true;
                    leftTimer = 0.5f;
                    rb.drag = 0;
                    if (leftOar == true && rightOar == false)
                    {
                        transform.Rotate(Vector3.forward, 8, 0);
                        rb.velocity = transform.up * movSpeed;
                    }
                    leftOarScript.upIsTheTarget = false;
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
                        transform.Rotate(Vector3.back, 8, 0);
                        rb.velocity = transform.up * movSpeed;
                    }
                    rightOarScript.upIsTheTarget = true;
                }
                if (Input.GetAxis("ControllerP2") <= -0.5 && latestControllerP2 == false)
                {
                    latestControllerP2 = true;
                    rightOar = true;
                    rightTimer = 0.5f;
                    rb.drag = 0;
                    if (leftOar == false && rightOar == true)
                    {
                        transform.Rotate(Vector3.back, 8, 0);
                        rb.velocity = transform.up * movSpeed;
                    }
                    rightOarScript.upIsTheTarget = false;
                }

            }
            if (leftOar == true && rightOar == true)
            {
                if (rightTimer > 0.45 && leftTimer > 0.45)
                {
                    transform.Rotate(0, 0, 0);
                    rb.velocity = transform.up * (movSpeed + 2);
                }
                else if (rightTimer > 0.35 && leftTimer > 0.35)
                {
                    transform.Rotate(0, 0, 0);
                    rb.velocity = transform.up * (movSpeed + 1);
                }
                else if (rightTimer > 0.25 && leftTimer > 0.25)
                {
                    transform.Rotate(0, 0, 0);
                    rb.velocity = transform.up * (movSpeed + 0.5f);
                }
                else
                {
                    transform.Rotate(0, 0, 0);
                    rb.velocity = transform.up * movSpeed;
                }
            }

            rb.drag = 0.1f;
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

    public void StartGame()
    {
        gameStarted = true;
    }

    public void MovmentUpgrade()
    {

        movSpeed++;
    }
}

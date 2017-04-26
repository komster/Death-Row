using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Camera_Movment : MonoBehaviour {

    public GameObject player;
    public Camera main;

    public Rigidbody2D rb;

    private float playerX;
    private float playerY;
    private float cameraX;
    private float cameraY;

    private float cameraSpeedY;
    private float cameraSpeedX;

    private bool gameStarted = false;
    private bool travelStageOn = true;


    void Start () {
        CS_Notify.Register(this, "StartGame");
        CS_Notify.Register(this, "ChangeStage");
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        if (gameStarted == true && travelStageOn == true)
        {
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
            cameraX = main.transform.position.x;
            cameraY = main.transform.position.y;

            if (playerY > cameraY - 30 && playerY < cameraY - 5)
            {
                cameraSpeedY = 0f;
            }

            if (playerY > cameraY - 5 && playerY < cameraY - 3)
            {
                cameraSpeedY = 2f;
            }
            if (playerY > cameraY - 3 && playerY < cameraY + 0)
            {
                cameraSpeedY = 4f;
            }
            if (playerY > cameraY + 0 && playerY < cameraY + 5)
            {
                cameraSpeedY = 6f;
            }




            if (playerX > cameraX - 5 && playerX < cameraX + 5)
            {
                cameraSpeedX = 0f;
            }

            if (playerX > cameraX + 5 && playerX < cameraX + 7)
            {
                cameraSpeedX = 2f;
            }
            if (playerX > cameraX + 7 && playerX < cameraX + 11)
            {
                cameraSpeedX = 4f;
            }

            if (playerX < cameraX - 5 && playerX > cameraX - 7)
            {
                cameraSpeedX = -2f;
            }
            if (playerX < cameraX - 7 && playerX > cameraX - 11)
            {
                cameraSpeedX = -4f;
            }

            rb.velocity = ((transform.up * cameraSpeedY) + (transform.right * cameraSpeedX));
        }
       

    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public void ChangeStage()
    {
        if (travelStageOn == true)
        {
            travelStageOn = false;
            main.transform.position = new Vector3(16.5f, 3,-10);

        }
        else
        {
            travelStageOn = true;
        }
    }
}

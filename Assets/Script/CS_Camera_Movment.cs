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

    public bool gameStarted = false;


    void Start () {
        CS_Notify.Register(this, "StartGame");
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        if (gameStarted == true)
        {
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
            cameraX = main.transform.position.x;
            cameraY = main.transform.position.y;

            if (playerY > cameraY - 30 && playerY < cameraY - 4)
            {
                cameraSpeedY = 0f;
            }

            if (playerY > cameraY - 4  && playerY < cameraY - 3)
            {
                cameraSpeedY = 3f;
            }
            if (playerY > cameraY - 3 && playerY < cameraY + 0)
            {
                cameraSpeedY = 6f;
            }
            if (playerY > cameraY + 0 && playerY < cameraY + 5)
            {
                cameraSpeedY = 9f;
            }




            if (playerX > cameraX - 3 && playerX < cameraX + 3)
            {
                cameraSpeedX = 0f;
            }

            if (playerX > cameraX + 3 && playerX < cameraX + 5)
            {
                cameraSpeedX = 3f;
            }
            if (playerX > cameraX + 5 && playerX < cameraX + 11)
            {
                cameraSpeedX = 6f;
            }

            if (playerX < cameraX - 3 && playerX > cameraX - 5)
            {
                cameraSpeedX = -3f;
            }
            if (playerX < cameraX - 5 && playerX > cameraX - 11)
            {
                cameraSpeedX = -6f;
            }

            rb.velocity = ((transform.up * cameraSpeedY) + (transform.right * cameraSpeedX));
        }
       

    }

    public void StartGame()
    {
        gameStarted = true;
    }
}

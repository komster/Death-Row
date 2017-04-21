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


    void Start () {
        main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        cameraX = main.transform.position.x;
        cameraY = main.transform.position.y;

        if (playerY > cameraY - 0.5 && playerY < cameraY + 0.5 )
        {
            cameraSpeedY = 0f;
        }

        if (playerY > cameraY + 0.5 && playerY < cameraY + 1)
        {
            cameraSpeedY = 2f;
        }
        if (playerY > cameraY + 1 && playerY < cameraY + 4)
        {
            cameraSpeedY = 4f;
        }

        if (playerY < cameraY - 0.5 && playerY > cameraY - 1)
        {
            cameraSpeedY = -2f;
        }
        if (playerY < cameraY - 1 && playerY > cameraY - 4)
        {
            cameraSpeedY = -4f;
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

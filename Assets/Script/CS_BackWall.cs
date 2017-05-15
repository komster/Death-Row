using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BackWall : MonoBehaviour
{

    public Transform player;
    private float movmentSpeed=5;

    private Vector3 disance;
    private float timer = 5;
    private Rigidbody2D rb;

    private bool gameStarted = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        disance = player.transform.position - this.transform.position;
        if (disance.y > 7)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * movmentSpeed);
            // transform.position= Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
        }
        if (disance.y < 9)
        {
            movmentSpeed = 5;
        }
        if (disance.y > 11)
        {
            movmentSpeed = 12;
        }
        if (disance.x < 1 && gameStarted == false)
        {
            transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy : MonoBehaviour {

    public Transform player;


    public GameObject cannonBall;
    public Transform[] cannons;
    private float cannonSpeed = 10;

    public int hp;

    private float shotDelay = 3;

    void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	void Update () {
        float distans = Vector3.Distance(transform.position, player.transform.position);

        float angle = CS_Utils.PointToDegree(player.position - this.transform.position);
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

        if (distans <= 20)
        {
            shotDelay -= Time.deltaTime;

            if (shotDelay <= 0)
            {
                for (int index = 0; index < cannons.Length; index++)
                {
                    cannonBall.transform.position = cannons[index].position;
                    GameObject temp = Instantiate(cannonBall);
                    Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                    rb.velocity = (transform.right * cannonSpeed);
                    shotDelay = 3;
                }
            }
        }
    }
}

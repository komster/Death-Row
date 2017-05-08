using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy_Battel : MonoBehaviour {

    public float movSpeed = 6;

    public Rigidbody2D rb;
    public Transform player;
    public GameObject cannonBall;

    public Transform[] leftCannon;
    public Transform[] rightCannon;
    public int hp;


    private Vector3 direction;
    private float cannonSpeed = 10;
    private float reloadTimer = 5;
    private bool reloding = false;


    void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	void Update () {

        float distans = Vector3.Distance(transform.position, player.transform.position);
        rb.velocity = transform.up * movSpeed;
        direction = transform.position - player.transform.position;
        direction.Normalize();
        float angle = Vector3.Angle(direction, transform.up);

        if (distans >10)
        {
            if (angle <= 130)
            {
                movSpeed = 4;
                if (angle <= 90)
                {
                    movSpeed = 2;
                }
                transform.Rotate(0, 0, direction.x * direction.y * 2);
            }
            else
            {
                movSpeed = 6;
            }
        }

        if (distans <= 10)
        {
            movSpeed = 2;

            if (reloding == false && angle < 95 && angle > 85)
            {
                if (direction.x * direction.y > 0)
                {
                    for (int index = 0; index < leftCannon.Length; index++)
                    {
                        cannonBall.transform.position = leftCannon[index].position;
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (-transform.right * cannonSpeed);
                        reloding = true;
                    }
                   
                }
                if (direction.x * direction.y < 0)
                {
                    for (int index = 0; index < rightCannon.Length; index++)
                    {
                        cannonBall.transform.position = rightCannon[index].position;
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (transform.right * cannonSpeed);
                        reloding = true;
                    }
 
                }

            }
            if (reloding == true)
            {
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0)
                {
                    reloding = false;
                    reloadTimer = 5;
                }
            }
        } 
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            hp--;
            Destroy(collision.gameObject);
        }
        if (hp == 0)
        {
            CS_Notify.Send(this, "PowerUp");
            Destroy(this.gameObject);
        }
    }
}

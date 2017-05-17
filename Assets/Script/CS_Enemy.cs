using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy : MonoBehaviour {
    public AudioSource spotted;

    public Transform player;

    
    public GameObject cannonBall;
    public GameObject cannonSmoke;
    public Transform[] cannons;
    public Transform[] rightCannonAimPositions;
    private float cannonSpeed = 10;

    public GameObject movmentPowerUp;
    public GameObject shotCoin;
    public GameObject biggerCoin;
    public GameObject cannonUpgrade;

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
            //spotted.Play();
            if (shotDelay <= 0)
            {
                for (int index = 0; index < cannons.Length; index++)
                {
                    cannonBall.transform.position = cannons[index].position;
                    GameObject temp = Instantiate(cannonBall);
                    Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                    rb.velocity = (transform.right * cannonSpeed);
                    shotDelay = 3;
                    Instantiate(cannonSmoke, cannons[index].transform.position, Quaternion.LookRotation(rightCannonAimPositions[index].transform.position - cannons[index].transform.position));
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CannonBallPlayer")
        {
            
            hp--;
            if (hp == 0)
            {
                int randomValue = Random.Range(1, 9);

                if (randomValue == 1)
                {
                    Instantiate<GameObject>(movmentPowerUp, this.transform.position, Quaternion.identity);
                }
                if (randomValue == 2)
                {
                    Instantiate<GameObject>(cannonUpgrade, this.transform.position, Quaternion.identity);
                }
                if (randomValue == 3)
                {
                    Instantiate<GameObject>(biggerCoin, this.transform.position, Quaternion.identity);
                }
                if (randomValue == 4)
                {
                    Instantiate<GameObject>(shotCoin, this.transform.position, Quaternion.identity);
                }

                Destroy(this.gameObject);
            }
        }
    }
}

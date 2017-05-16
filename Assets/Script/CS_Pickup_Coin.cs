using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Pickup_Coin : MonoBehaviour {
    private CS_Gamemanager gameManager;
    public int coinValue;
    public AudioClip sound;
    private CS_Gamemanager manager;

    private bool shotCoins = false;
    
    private CS_Player_Movment Movement;
    private movment movement;
	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        gameManager = FindObjectOfType<CS_Gamemanager>();
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player_Movment>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movment>();
        CS_Notify.Register(this, "BiggerCoins");
        CS_Notify.Register(this, "ShotCoins");
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (shotCoins == true)
        {
            if (other.gameObject.tag == "CannonBallPlayer")
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);
                gameManager.InitScore(coinValue);
                Destroy(this.gameObject);
            }
        }
        
        if(other.gameObject.name == "Player")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            gameManager.InitScore(coinValue);
            manager.checkForBoost();
            //manager.coinPicked = true;
            Destroy(this.gameObject);
            
        }
    }
    

    public void BiggerCoins()
    {
        this.transform.localScale = new Vector3(2, 2, 2);
    }

    public void ShotCoins()
    {
        if (shotCoins == false)
        {
            shotCoins = true;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Pickup_Coin : MonoBehaviour {
    private CS_Gamemanager gameManager;
    public int coinValue;
    public AudioClip sound;
    private CS_Gamemanager manager;
    
    public float time = 3f;
    private CS_Player_Movment Movement;
    private movment movement;
	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        gameManager = FindObjectOfType<CS_Gamemanager>();
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player_Movment>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movment>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="CannonBall")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            gameManager.InitScore(coinValue);
            Destroy(this.gameObject);
        }
        if(other.gameObject.name == "Player")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            gameManager.InitScore(coinValue);
            manager.coinPicked = true;
            Destroy(this.gameObject);
            
        }
    }
    
    
}

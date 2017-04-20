using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Pickup_Coin : MonoBehaviour {
    private CS_Gamemanager gameManager;
    public int coinValue;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<CS_Gamemanager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            gameManager.InitScore(coinValue);
            Destroy(this.gameObject);
        }
        
        
    }
}

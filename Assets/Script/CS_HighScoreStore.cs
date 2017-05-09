using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_HighScoreStore : MonoBehaviour {
    public CS_Player playerLife;
    public CS_Gamemanager playerScore;
    
    
    void Start ()
    {
        playerScore = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        setupScore();
	}
    public void setupScore()
    {
        if(playerLife.dead == true)
        {
           
            PlayerPrefs.SetInt("Highscore", playerScore.coins);
          
        }
    }
}

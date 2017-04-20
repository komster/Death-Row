using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_Gamemanager : MonoBehaviour {

    public int coins;
    public Text score;
	// Use this for initialization
	void Start () {
        score = GameObject.Find("score").GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitScore(int nrOfCoins)
    {
        coins += nrOfCoins;
        score.text = "score: " + coins;

    }
}

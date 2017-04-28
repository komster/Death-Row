using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_Gamemanager : MonoBehaviour {

    public int coins;
    public Text score;
    public Text score1;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitScore(int nrOfCoins)
    {
        coins += nrOfCoins;
        score.text = "score: " + coins;
        score1.text = "score: " + coins;

    }
}

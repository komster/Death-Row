using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_Gamemanager : MonoBehaviour {

    public int coins;
    public Text score;
    
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
    }
   
}

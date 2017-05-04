using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_Gamemanager : MonoBehaviour {

    public int coins;
    public Text score;
    public bool coinPicked = false;
    private CS_Player_Movment Movement;
    private movment movement;
    private CS_Pickup_Coin pickS;
    // Use this for initialization
    void Start () {
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player_Movment>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movment>();
       // pickS = GameObject.FindGameObjectWithTag("Coin").GetComponent<CS_Pickup_Coin>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitScore(int nrOfCoins)
    {
        coins += nrOfCoins;
        score.text = "score: " + coins;
        
    }
    void checkForBoost()
    {
        if(coinPicked == true)
        {
            StartCoroutine(boost());
        }
        
    }
    private IEnumerator boost()
    {

        //Movement.movSpeed += 10f;
        movement.MovSpeed = 10f;
        yield return new WaitForSeconds(0.5f);
        //Movement.movSpeed -= 10f;
        movement.MovSpeed = 6f;
        Debug.Log("test");
        coinPicked = false;

    }
}

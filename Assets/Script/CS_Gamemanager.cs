using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_Gamemanager : MonoBehaviour {

    public int coins;
    public Text score;
    public CS_Gamemanager scoreCoins;
    private CS_Stages stage;
    public GameObject coinPre;
    public CS_Player checkIfHit;
    private CS_Player_Movment Movement;
    private movment movement;
    private CS_Pickup_Coin pickS;
    
    void Start () {
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player_Movment>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movment>();
        checkIfHit = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player>();
        stage = this.gameObject.GetComponent<CS_Stages>();
        
        scoreCoins = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (checkIfHit.gotHit == true)
        {
            decreScore();
            checkIfHit.gotHit = false;
        }
    }
    public void decreScore()
    {
        coins -= 300;
        score.text = "score: " + coins;
        Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f)), Quaternion.identity);
        Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f)), Quaternion.identity);
        Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f)), Quaternion.identity);
    }
    public void InitScore(int nrOfCoins)
    {
        coins += nrOfCoins;
        score.text = "score: " + coins;
        
    }
    public void checkForBoost()
    {
        StartCoroutine(boost());
        
    }
    
    private IEnumerator boost()
    {

        Movement.movSpeed += 8f;
        movement.MovSpeed += 8f;
        yield return new WaitForSeconds(3f);
        Movement.movSpeed -= 8f;
        movement.MovSpeed -= 8f;
        Debug.Log("Boosted");
        


    }
}

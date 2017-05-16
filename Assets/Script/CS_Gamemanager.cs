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
    public float timeInGame;
    public AudioSource boostSound;
    void Start () {
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player_Movment>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movment>();
        checkIfHit = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player>();
        stage = this.gameObject.GetComponent<CS_Stages>();
        
        scoreCoins = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
    }
	
	// Update is called once per frame
	void Update () {
        timeInGame += Time.deltaTime;
        if (checkIfHit.gotHit == true)
        {
            decreScore();
            checkIfHit.gotHit = false;
        }
    }
    public void decreScore()
    {

        if (coins == 100)
        {
            coins -= 100;
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            
        }
        else if (coins == 200)
        {
            coins -= 200;
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);

        }
        else if (coins >= 300)
        {
            coins -= 300;
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
        }
        else if (coins <= 0)
        {

        }
        score.text = "score: " + coins;
        
    }
    public void InitScore(int nrOfCoins)
    {
        coins += nrOfCoins;
        score.text = "score: " + coins;
        
    }
    public void checkForBoost()
    {
        StartCoroutine(boost());
        //boostSound.Play();
    }
    
    private IEnumerator boost()
    {

        Movement.movSpeed += 2f;
        movement.MovSpeed += 2f;
        yield return new WaitForSeconds(3f);
        Movement.movSpeed -= 2f;
        movement.MovSpeed -= 2f;
        Debug.Log("Boosted");
        


    }
}

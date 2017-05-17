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
    public Text pickUpParticleText;
    public GameObject lossParticle;
 


    private int previousScore;
    private float pointAnimDurationSec = 1f;
    private float pointAnimTimer = 0f;
    private float prcComplete;
    void Start () {
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player_Movment>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movment>();
        checkIfHit = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player>();
        stage = this.gameObject.GetComponent<CS_Stages>();
        pickUpParticleText = GameObject.Find("Text_ParticleMaterialMaker").GetComponentInChildren<Text>();
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
        pointAnimTimer += Time.deltaTime;
        prcComplete = pointAnimTimer / pointAnimDurationSec;
        score.text = "SCORE: " + Mathf.RoundToInt(Mathf.Lerp(previousScore, coins, prcComplete));

    }
    public void decreScore()
    {

        if (coins == 100)
        {
            previousScore = coins;
            coins -= 100;
            pickUpParticleText.text = "- " + 100;
            pointAnimTimer = 0;
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(lossParticle, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position, Quaternion.Euler(90, 0, 0));


        }
        else if (coins == 200)
        {
            previousScore = coins;
            coins -= 200;
            pickUpParticleText.text = "- " + 200;
            pointAnimTimer = 0;
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(lossParticle, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position, Quaternion.Euler(90, 0, 0));
        

        }
        else if (coins >= 300)
        {
            previousScore = coins;
            coins -= 300;
            pickUpParticleText.text = "- " + 300;
            pointAnimTimer = 0;
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(coinPre, checkIfHit.playerpos + new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0), Quaternion.identity);
            Instantiate(lossParticle, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position, Quaternion.Euler(90, 0, 0));
        }
        else if (coins <= 0)
        {

        }
        //score.text = "score: " + coins;
        
    }
    public void InitScore(int nrOfCoins)
    {
        previousScore = coins;
        pickUpParticleText.text = "+ " + nrOfCoins;
        coins += nrOfCoins;
        pointAnimTimer = 0;
       // score.text = "score: " + coins;
        
    }
    public void checkForBoost()
    {
        StartCoroutine(boost());
        boostSound.Play();
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

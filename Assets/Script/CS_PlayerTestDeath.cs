using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_PlayerTestDeath : MonoBehaviour {
    public CS_Gamemanager score;
    public CS_HighscoreBoard board;
	// Use this for initialization
	void Start () {
        score = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        board = GameObject.Find("MainMenu").GetComponent<CS_HighscoreBoard>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Medium_Enemy")
        {
            death();
        }
    }
    public void death()
    {
        /*if (PlayerPrefs.GetFloat("Highscore") < score.coins)
        {
            PlayerPrefs.SetFloat("Highscore", score.coins);
        }*/
       
        SceneManager.LoadScene(0);
        board.CheckForHScore(score.coins);
    }
}

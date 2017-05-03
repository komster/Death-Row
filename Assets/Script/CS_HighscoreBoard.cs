using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_HighscoreBoard : MonoBehaviour {
    public Text highscoreText;
    // Use this for initialization
    void Start () {
        highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

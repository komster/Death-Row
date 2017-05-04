using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_HighscoreBoard : MonoBehaviour {
    public Text[] highScores;

    int[] highScoreValues;
    private bool callOnce = false;
    public int Value;
    //public Text highscoreText;
    // Use this for initialization
    
    void Start ()
    {
        
        inherit();
       // highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        highScoreValues = new int[highScores.Length];
        for(int x = 0; x < highScores.Length; x++)
        {
            highScoreValues[x] = PlayerPrefs.GetInt("highScoreValues" + x);
        }
        WriteScores();
    }
    
    void inherit()
    {
        Value = PlayerPrefs.GetInt("Highscore");
        //CheckForHScore(PlayerPrefs.GetInt("Highscore"));
        
    }
	void saveScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            PlayerPrefs.SetInt("highScoreValues" + x, highScoreValues[x]);
        }
    }
    public void CheckForHScore()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            if(Value > highScoreValues [x])
            {
                for(int y = highScores.Length - 1; y > x; y--)
                {
                    highScoreValues[y] = highScoreValues[y - 1];
                }
                highScoreValues[x] = Value;
                WriteScores();
                saveScores();
                break;
            }
        }
    }
    void WriteScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            highScores[x].text = highScoreValues[x].ToString();
        }
    }// Update is called once per frame
	void Update () {
        if (callOnce == false)
        {
            CheckForHScore();
            callOnce = true;
        }
    }
}

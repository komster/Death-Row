using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_HighscoreBoard : MonoBehaviour {
    public Text[] highScores;

    int[] highScoreValues;

    //public Text highscoreText;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start ()
    {
        
       // highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        highScoreValues = new int[highScores.Length];
        for(int x = 0; x < highScores.Length; x++)
        {
            highScoreValues[x] = PlayerPrefs.GetInt("highScoreValues" + x);
        }
        WriteScores();
    }
	void saveScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            PlayerPrefs.SetInt("highScoreValues" + x, highScoreValues[x]);
        }
    }
    public void CheckForHScore(int value)
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            if(value > highScoreValues [x])
            {
                for(int y = highScores.Length - 1; y > x; y--)
                {
                    highScoreValues[y] = highScoreValues[y - 1];
                }
                highScoreValues[x] = value;
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
		
	}
}

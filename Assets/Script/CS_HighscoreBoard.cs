using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_HighscoreBoard : MonoBehaviour {
    public Text[] highScores;

    int[] highScoreValues;
    
    string[] highScoreNames;
    
    
    
    void Start ()
    {
       
        highScoreValues = new int[highScores.Length];
        highScoreNames = new string[highScores.Length];
        for(int x = 0; x < highScores.Length; x++)
        {
            highScoreValues[x] = PlayerPrefs.GetInt("highScoreValues" + x);
            highScoreNames[x] = PlayerPrefs.GetString("highScoreNames" + x);
        }
        
        WriteScores();
    }
    
    
	void saveScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            PlayerPrefs.SetInt("highScoreValues" + x, highScoreValues[x]);
            PlayerPrefs.SetString("highScoreNames" + x, highScoreNames [x]);
            
        }
    }
    public void CheckForHScore(int _value, string _userName)
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            if(_value > highScoreValues [x])
            {
                for(int y = highScores.Length - 1; y > x; y--)
                {
                    highScoreValues[y] = highScoreValues[y - 1];
                    highScoreNames[y] = highScoreNames[y - 1];
                }
                highScoreValues[x] = _value;
                highScoreNames[x] = _userName;

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
            highScores[x].text = highScoreNames[x] + ":" + highScoreValues[x].ToString();
        }
    }
	
}

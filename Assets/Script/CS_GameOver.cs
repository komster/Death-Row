using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_GameOver : MonoBehaviour {
    // public InputField playerName;

    public CS_HighScoreInput hSI;

    // Use this for initialization
    void Start ()
    {
        hSI = GameObject.Find("HighScoreInput").GetComponent<CS_HighScoreInput>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hSI.goToMainMenu == true)
        {
            PlayerPrefs.SetString("UserInput", hSI.combinedPlayersEntry);
            SceneManager.LoadScene(0);
        }
    }
    /*public void checkIfEmpty()
    {
        if(playerName.text=="")
        {
            Debug.Log("Put in name!");
        }
        else
        {
            submitButton();
        }
    }
    public void submitButton()
    {
        PlayerPrefs.SetString("UserInput", playerName.text);
        SceneManager.LoadScene(0);
    }*/
}

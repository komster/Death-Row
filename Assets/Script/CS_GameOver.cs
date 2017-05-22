using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_GameOver : MonoBehaviour {
    // public InputField playerName;

    public CS_HighScoreInput hSI;
    public List<Text> score;
    public CS_Gamemanager gM;

    // Use this for initialization
    void Start ()
    {
        hSI = GameObject.Find("HighScoreInput").GetComponent<CS_HighScoreInput>();
        gM = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        foreach(Transform child in this.transform)
        {
            if (child.tag == "Score")
            {
                score.Add(child.GetComponent<Text>());

            }
        }
        for(int i = 0; i < score.Count; i++)
        {
            score[i].text ="" + gM.coins;
        }
       
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

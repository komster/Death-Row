using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_GameOver : MonoBehaviour {
    public InputField playerName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void checkIfEmpty()
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
    }
}

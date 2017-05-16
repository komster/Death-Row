using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_TextParticle : MonoBehaviour {

    public Text scorePickUpText;

	// Use this for initialization
	void Start ()
    {
        scorePickUpText = this.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void ChangeTextOfScorePickUp(string neoText)
    {
        scorePickUpText.text = neoText;
    }

}

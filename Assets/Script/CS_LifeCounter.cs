using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_LifeCounter : MonoBehaviour {
    public Sprite[] LifeSprites;
    public Image LifeUI;
    private CS_Player player;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<CS_Player>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void life()
    {
        LifeUI.sprite = LifeSprites[player.hp];
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_DeathCounter : MonoBehaviour {
    public float timeToDie;
    public Text dCounter;

    private Vector3 smallHUDPosition= new Vector3(300,400,0);
    private Vector3 bigHudPosition=new Vector3(0,0,0);

    private Vector3 bigScale = new Vector3(2.5f, 2.5f, 2.5f);
    private Vector3 smallScale=new Vector3(1f,1f,1f);

    private bool timerHasStarted;
    private bool timeToBlink;
    private float minutes;
    private float seconds;
    private float blinkInterval = 0.5f;

    // Use this for initialization
    void Start ()
    {
        
        CS_Notify.Register(this, "StartTimer");
        timeToDie =300f;
        timerHasStarted = false;
        timeToBlink = false;
        dCounter = this.gameObject.GetComponent<Text>();
        dCounter.text = "";
        StartTimer();


    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (timerHasStarted == true)
        {
            DisplayTimer();   
            timeToDie -= Time.deltaTime;

            this.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(this.GetComponent<RectTransform>().localPosition, smallHUDPosition, 0.005f);
            this.GetComponent<RectTransform>().localScale = Vector3.Lerp(this.GetComponent<RectTransform>().localScale, smallScale, 0.005f);
        
        }
        if (timeToBlink==true)
        {
            this.GetComponent<Text>().enabled = (Mathf.PingPong(Time.time, blinkInterval) > (blinkInterval / 2f));
        }
    }

    private void DisplayTimer()
    {
        minutes = Mathf.Floor(timeToDie / 60);
        seconds = Mathf.RoundToInt(timeToDie % 60);
        dCounter.text = "" + minutes + " : " + seconds;
    }

    public void StartTimer()
    {
        this.GetComponent<RectTransform>().anchoredPosition = bigHudPosition;
        this.GetComponent<RectTransform>().localScale = bigScale;
        StartCoroutine(TimeTostart());
        
    }
    private IEnumerator TimeTostart()
    {
        DisplayTimer();
        timeToBlink = true;
        yield return new WaitForSeconds(1);
        this.GetComponent<Text>().enabled = true;
        timerHasStarted = true;
        timeToBlink = false;
    }
}
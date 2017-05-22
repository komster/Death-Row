using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_DeathCounter : MonoBehaviour {
    public float timeToDie;
    public List<Text> dCounter;
    public List<Text> prompt;
    public CS_Player pl;
    public List<Transform> images;
    public List<Transform> arrows;
    public GameObject jaw;
    public CS_PrograssBar csPB;

    private Vector3 smallHUDPosition= new Vector3(140, 470, 0);
    private Vector3 bigHudPosition=new Vector3(0,0,0);

    private Vector3 bigScale = new Vector3(2.5f, 2.5f, 2.5f);
    private Vector3 smallScale=new Vector3(1f,1f,1f);

    private bool timerHasStarted;
    private bool timeToBlink;
    public float minutes;
    public float seconds;
    private float blinkInterval = 0.1f;

    // Use this for initialization
    void Start ()
    {
       
        CS_Notify.Register(this, "StartTimer");
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player>();
        timeToDie =300f;
        timerHasStarted = false;
        timeToBlink = false;
        csPB = GameObject.Find("ProgressBar").GetComponent<CS_PrograssBar>();
        foreach (Transform child in this.transform)
        {
            if (child.tag == ("Text"))
            {
                
                dCounter.Add(child.GetComponent<Text>());
                
            }

        }
        for (int i = 0; i < dCounter.Count; i++)
        {
            dCounter[i].text = "";
        }

       
        foreach (Transform child in this.transform)
        {
            if (child.tag == "Image")
            {
                images.Add(child);
            }
        }
        foreach (Transform child in this.transform)
        {
            if (child.tag == "Arrow")
            {
                arrows.Add(child);
            }
        }
        for (int i=0; i < images.Count; i++)
        {
            images[i].GetComponent<Image>().enabled = false;
        }
        for (int i = 0; i < arrows.Count; i++)
        {
            arrows[i].GetComponent<Image>().enabled = false;
        }

        foreach (Transform child in this.transform)
        {
            if (child.tag == ("Prompt"))
            {

                prompt.Add(child.GetComponent<Text>());

            }

        }
        for (int i = 0; i < prompt.Count; i++)
        {
            prompt[i].GetComponent<Text>().enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (timerHasStarted == true)
        {
            DisplayTimer();   
            timeToDie -= Time.deltaTime;

            this.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(this.GetComponent<RectTransform>().localPosition, smallHUDPosition, 0.05f);
            this.GetComponent<RectTransform>().localScale = Vector3.Lerp(this.GetComponent<RectTransform>().localScale, smallScale, 0.05f);
           
        }
        if (timeToBlink==true)
        {
            for (int i = 0; i < dCounter.Count; i++)
            {
                dCounter[i].GetComponent<Text>().enabled = (Mathf.PingPong(Time.time, blinkInterval) > (blinkInterval / 2f));
            }
            for (int i = 0; i < arrows.Count; i++)
            {
                arrows[i].GetComponent<Image>().enabled = (Mathf.PingPong(Time.time, blinkInterval) > (blinkInterval / 2f));
            }

        }
        if (timeToDie == 0 || timeToDie < 0)
        {
            pl.death();
        }
    }

    private void DisplayTimer()
    {
        minutes = Mathf.Floor(timeToDie / 60);
        seconds = Mathf.RoundToInt(timeToDie % 60);
        for (int i = 0; i < dCounter.Count; i++)
        {
            dCounter[i].text = "" + minutes + " : " + seconds;
        }
    }

    public void StartTimer()
    {
        this.GetComponent<RectTransform>().anchoredPosition = bigHudPosition;
        this.GetComponent<RectTransform>().localScale = bigScale;
        csPB.onScreen = true;
        csPB.pointAnimTimer = 0;

        StartCoroutine(TimeTostart());
        
    }
    private IEnumerator TimeTostart()
    {
        DisplayTimer();
        timeToBlink = true;
        for (int i = 0; i < images.Count; i++)
        {
            images[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < prompt.Count; i++)
        {
            prompt[i].GetComponent<Text>().enabled = true;
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < dCounter.Count; i++)
        {
            dCounter[i].GetComponent<Text>().enabled = true;
        }
        timerHasStarted = true;
        timeToBlink = false;
        for (int i = 0; i < arrows.Count; i++)
        {
            arrows[i].GetComponent<Image>().enabled = false;
        }
        for (int i = 0; i < prompt.Count; i++)
        {
            prompt[i].GetComponent<Text>().enabled = false;
        }
    }
}

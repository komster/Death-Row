using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PrograssBar : MonoBehaviour {

    public RectTransform player;
    public bool onScreen = false;
    public float pointAnimTimer = 0f;

    private Vector3 uIOnscreenPosition = new Vector3(822, 82, 0);
    private Vector3 uIOffscreenPosition = new Vector3(1400, 82, 0);
    private Vector3 position;
    private float pointAnimDurationSec = 1f;
 
    private float prcComplete;
    private int appearTimes;
   
    

    void Start () {
        appearTimes = 0;
        CS_Notify.Register(this, "NextTile");
        position = player.position;
	}
    void Update()
    {
        if (onScreen == true)
        {
            pointAnimTimer += Time.deltaTime;
            prcComplete = pointAnimTimer / pointAnimDurationSec;
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(uIOffscreenPosition, uIOnscreenPosition, prcComplete);
        }
        if(onScreen == false)
        {
            pointAnimTimer += Time.deltaTime;
            prcComplete = pointAnimTimer / pointAnimDurationSec;
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(uIOnscreenPosition, uIOffscreenPosition, prcComplete);
        }
    }

    public void NextTile()
    {
        
        position.y = player.localPosition.y;
        position.y += 40;
        position.x = 0;
        player.localPosition = position;
        /* appearTimes++;
         if (appearTimes == 1 || appearTimes == 4 || appearTimes == 8 || appearTimes == 12 || appearTimes == 14)
         {
             pointAnimTimer = 0;
             onScreen = true;
             StartCoroutine(TimeOnScreen());
         }*/

    }
    /*private IEnumerator TimeOnScreen()
    {
        yield return new WaitForSeconds(2);
        pointAnimTimer = 0;
        onScreen = false;
    }*/
}

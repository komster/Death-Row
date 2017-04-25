using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy_Battel : MonoBehaviour {

    public bool on = false;

    public GameObject leftSide;
    public GameObject rightSide;

    private GameObject targert;

    public float movmentSpeed;



    void Start () {
		
	}
	
	void Update () {
        float distanceLeft = Vector3.Distance(transform.position, leftSide.transform.position);
        float distanceRight = Vector3.Distance(transform.position, rightSide.transform.position);
        if (distanceLeft < distanceRight)
        {
            targert = leftSide;
        }
        else
        {
            targert = rightSide;
        }
        transform.position = Vector3.MoveTowards(transform.position, targert.transform.position, Time.deltaTime * movmentSpeed);
    }

    void OnBecameInvisible()
    {
        if (on == true)
        {
            CS_Notify.Send(this, "ZoomOut");
            CS_Notify.Send(this, "StopZoomIn");
        }
        
    }

    private void OnBecameVisible()
    {
        if (on == true)
        {
            CS_Notify.Send(this, "StopZoomOut");
            CS_Notify.Send(this, "ZoomIn");
        }
  
    }
}

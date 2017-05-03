using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_TravelStage : MonoBehaviour {

    private bool travelStageOn = true;

	void Start () {
        CS_Notify.Register(this, "TravelStageOn");
        CS_Notify.Register(this, "TravelStageOff");
    }
	
	void Update () {
		
	}

    public void TravelStageOn()
    {
        CS_Notify.Send(this, "BattelStafeOff");
        CS_Notify.Send(this, "TurnOnWorldSpawn");
        CS_Notify.Send(this, "ChangeToTravelCamera");

    }
    public void TravelStageOff()
    {
        CS_Notify.Send(this, "TurnOffWorldSpawn");
    }
}

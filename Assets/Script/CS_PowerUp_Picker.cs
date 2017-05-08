using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PowerUp_Picker : MonoBehaviour {

    public GameObject[] leftPowerUp = new GameObject[3];
    public GameObject[] rightPowerUp = new GameObject[3];

    private int leftValue = 0;
    private int rightValue = 0;

    private bool picking = false;

    void Start () {
        CS_Notify.Register(this, "PowerUp");
	}
	void Update () {
        if (picking == true)
        {
            if (!leftPowerUp[leftValue].activeInHierarchy)
            {
                leftPowerUp[leftValue].SetActive(true);
            }
            if (!rightPowerUp[rightValue].activeInHierarchy)
            {
                rightPowerUp[rightValue].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                if (leftValue == 0)
                {
                    CS_Notify.Send(this, "MovmentUpgrade");
                }
                if (leftValue == 1)
                {
                    CS_Notify.Send(this, "ReloadUpgrade");
                }
                if (leftValue == 2)
                {
                    CS_Notify.Send(this, "CannonUpgrade");
                }
                picking = false;
                leftPowerUp[leftValue].SetActive(false);
                rightPowerUp[rightValue].SetActive(false);
                CS_Notify.Send(this, "ChangeStage");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                if (rightValue == 0)
                {
                    CS_Notify.Send(this, "MovmentUpgrade");
                }
                if (rightValue == 1)
                {
                    CS_Notify.Send(this, "ReloadUpgrade");
                }
                if (rightValue == 2)
                {
                    CS_Notify.Send(this, "CannonUpgrade");
                }
                picking = false;
                leftPowerUp[leftValue].SetActive(false);
                rightPowerUp[rightValue].SetActive(false);
                CS_Notify.Send(this, "ChangeStage");
            }
        }
	}

    public void PowerUp()
    {
        leftValue = Random.Range(0,3);
        rightValue = Random.Range(0,3);
        picking = true;
    }
}

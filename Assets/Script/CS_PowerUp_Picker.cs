using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PowerUp_Picker : MonoBehaviour {

    public GameObject[] leftPowerUp = new GameObject[4];
    public GameObject[] rightPowerUp = new GameObject[4];

    private int leftValue = 0;
    private int rightValue = 0;

    private bool picking = false;

    private bool biggerCoins = false;
    private bool shotCoins = false;

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
                    CS_Notify.Send(this, "CannonUpgrad");
                }
                if (rightValue == 2)
                {
                    shotCoins = true;
                }
                if (rightValue == 3)
                {
                    biggerCoins = true;
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
                    CS_Notify.Send(this, "CannonUpgrad");
                }
                if (rightValue == 2)
                {
                    shotCoins = true;
                }
                if (rightValue == 3)
                {
                    biggerCoins = true;
                }
                picking = false;
                leftPowerUp[leftValue].SetActive(false);
                rightPowerUp[rightValue].SetActive(false);
                CS_Notify.Send(this, "ChangeStage");
            }
        }

        if (biggerCoins == true)
        {
            CS_Notify.Send(this, "BiggerCoins");
        }
        if (shotCoins == true)
        {
            CS_Notify.Send(this, "ShotCoins");
        }
	}

    public void PowerUp()
    {
        leftValue = Random.Range(1,2);
        rightValue = Random.Range(0,4);
        picking = true;
    }
}

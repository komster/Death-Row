using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PowerUp_Picker : MonoBehaviour {

    private bool biggerCoins = false;
    private bool shotCoins = false;

    void Start () {
        CS_Notify.Register(this, "BiggerCoinsTrue");
        CS_Notify.Register(this, "ShotCoinsTrue");
    }
	void Update () {
     

        if (biggerCoins == true)
        {
            CS_Notify.Send(this, "BiggerCoins");
        }
        if (shotCoins == true)
        {
            CS_Notify.Send(this, "ShotCoins");
        }
	}

    public void BiggerCoinsTrue()
    {
        biggerCoins = true;
    }

    public void ShotCoinsTrue()
    {
        shotCoins = true;
    }
}

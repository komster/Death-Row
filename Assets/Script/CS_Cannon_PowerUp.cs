using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Cannon_PowerUp : MonoBehaviour {

    public GameObject cannon1;
    public GameObject cannon2;

	void Start () {
        CS_Notify.Register(this, "CannonUpgrad");
	}

    public void CannonUpgrad()
    {
        cannon1.SetActive(true);
        cannon2.SetActive(true);
    }
}

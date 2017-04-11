using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CannonBall_Range : MonoBehaviour {

    public float range;

	void Start () {
		
	}
	
	void Update () {
        range -= Time.deltaTime;
        if (range <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}

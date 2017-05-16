﻿using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"|| collision.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}

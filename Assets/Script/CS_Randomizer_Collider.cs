using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Randomizer_Collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 
	}
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Island")
        {
            col.gameObject.SendMessage("collided");
            Destroy(this.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
       
	}
   
    
}

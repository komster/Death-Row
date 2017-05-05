using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player : MonoBehaviour {


    public int hp;

    void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            hp--;
        }

        if (collision.gameObject.tag == "End")
        {
            Debug.Log("jay");
        }

        if (hp < 0)
        {

        }
    }
}

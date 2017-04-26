using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Enemy_Battel : MonoBehaviour {

    public bool on = false;

    public GameObject leftSide;
    public GameObject rightSide;

    public GameObject player;

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

        float angel = Vector3.Angle(transform.position,player.transform.position);
        Debug.Log(angel);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Cannons : MonoBehaviour {

    public GameObject[] cannon;
    public GameObject cannonBall;

    public int cannonSpeed;

    public Transform[] leftCannonsSpawnPoints;
    public Transform[] rightCannonsSpawnPoints;

    void Start () {

	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            for (int index = 0; index < cannon.Length; index++)
            {
                if (cannon[index].activeInHierarchy)
                {
                    cannonBall.transform.position = leftCannonsSpawnPoints[index].transform.position;
                    Debug.Log(cannonBall.transform.rotation);
                    GameObject temp = Instantiate(cannonBall);
                    Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                    rb.velocity = (-transform.right * cannonSpeed);
                };
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            for (int index = 0; index < cannon.Length; index++)
            {
                if (cannon[index].activeInHierarchy)
                {
                    cannonBall.transform.position = rightCannonsSpawnPoints[index].transform.position;
                    GameObject temp = Instantiate(cannonBall);
                    Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                    rb.velocity = (transform.right * cannonSpeed);
                }
            }
        }
    }
}

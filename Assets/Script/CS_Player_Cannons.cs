using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Cannons : MonoBehaviour
{

    public GameObject[] cannon;
    public GameObject cannonBall;

    public int cannonSpeed;
    public float relodSpeed;

    public Transform[] leftCannonsSpawnPoints;
    public Transform[] rightCannonsSpawnPoints;

    public Transform[] leftCannons;
    public Transform[] rightCannons;

    private float leftRelodTimer;
    private float rightRelodTimer;

    private int leftCannonsPositon = 0;
    private int rightCannonsPositon = 0;

    void Start()
    {
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (leftRelodTimer <= 0)
            {
                for (int index = 0; index < cannon.Length; index++)
                {
                    if (cannon[index].activeInHierarchy)
                    {
                        cannonBall.transform.position = leftCannonsSpawnPoints[index].transform.position;
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (leftCannons[index].transform.up * cannonSpeed);
                        leftRelodTimer = relodSpeed;
                    };
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            if (rightRelodTimer <= 0)
            {
                for (int index = 0; index < cannon.Length; index++)
                {
                    if (cannon[index].activeInHierarchy)
                    {
                        cannonBall.transform.position = rightCannonsSpawnPoints[index].transform.position;
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (rightCannons[index].transform.up * cannonSpeed);
                        rightRelodTimer = relodSpeed;
                    }
                }
            }

        }


        leftRelodTimer -= Time.deltaTime;
        rightRelodTimer -= Time.deltaTime;

        if (Input.GetAxis("CannonP1") == 1)
        {
            if (leftCannonsPositon < 30)
            {
                leftCannons[1].Rotate(0, 0, -0.5F);
                leftCannons[2].Rotate(0, 0, -1F);
                leftCannons[3].Rotate(0, 0, 0.5F);
                leftCannons[4].Rotate(0, 0, 1F);
                leftCannonsPositon++;
            }
        }
        if (Input.GetAxis("CannonP1") == -1)
        {
            if (leftCannonsPositon > 0)
            {
                leftCannons[1].Rotate(0, 0, 0.5F);
                leftCannons[2].Rotate(0, 0, 1F);
                leftCannons[3].Rotate(0, 0, -0.5F);
                leftCannons[4].Rotate(0, 0, -1F);
                leftCannonsPositon--;
            }
        }
        if (Input.GetAxis("CannonP2") == 1)
        {
            if (rightCannonsPositon < 30)
            {
                rightCannons[1].Rotate(0, 0, -0.5F);
                rightCannons[2].Rotate(0, 0, -1F);
                rightCannons[3].Rotate(0, 0, 0.5F);
                rightCannons[4].Rotate(0, 0, 1F);
                rightCannonsPositon++;
            }
        }
        if (Input.GetAxis("CannonP2") == -1)
        {
            if (rightCannonsPositon > 0)
            {
                rightCannons[1].Rotate(0, 0, 0.5F);
                rightCannons[2].Rotate(0, 0, 1F);
                rightCannons[3].Rotate(0, 0, -0.5F);
                rightCannons[4].Rotate(0, 0, -1F);
                rightCannonsPositon--;
            }
        }


    }
}

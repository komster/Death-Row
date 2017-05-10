using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Cannons : MonoBehaviour
{
    public AudioSource shot;
    public GameObject cannonSmoke;

    public GameObject cannonBall;
    public GameObject[] cannons;

    public int cannonSpeed;

    public Transform[] leftCannonsSpawnPoints;
    public Transform[] rightCannonsSpawnPoints;

    public Transform[] leftCannonAimPositions;
    public Transform[] rightCannonAimPositions;

    private bool leftReloaded = true;
    private bool rightReloaded = true;

    private bool left1 = false;
    private bool left2 = false;
    private bool right1 = false;
    private bool right2 = false;


    private int leftCannonsPositon = 0;
    private int rightCannonsPositon = 0;

    void Start()
    {
        shot = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.A))
        {
            if (leftReloaded == true)
            {
                shot.Play();
                for (int index = 0; index < cannons.Length; index++)
                {
                    if (cannons[index].activeInHierarchy)
                    {
                        cannonBall.transform.position = new Vector3(leftCannonsSpawnPoints[index].transform.position.x, leftCannonsSpawnPoints[index].transform.position.y, 0);
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (-transform.right * cannonSpeed);
                        Instantiate(cannonSmoke, leftCannonsSpawnPoints[index].transform.position, Quaternion.LookRotation(leftCannonAimPositions[index].transform.position - leftCannonsSpawnPoints[index].transform.position));

                    };
                }

                leftReloaded = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            if (rightReloaded == true)
            {
                shot.Play();
                for (int index = 0; index < cannons.Length; index++)
                {
                    if (cannons[index].activeInHierarchy)
                    {
                        cannonBall.transform.position = new Vector3(rightCannonsSpawnPoints[index].transform.position.x, rightCannonsSpawnPoints[index].transform.position.y, 0);
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (transform.right * cannonSpeed);
                        Instantiate(cannonSmoke, rightCannonsSpawnPoints[index].transform.position, Quaternion.LookRotation(rightCannonAimPositions[index].transform.position - rightCannonsSpawnPoints[index].transform.position));
                    }
                }

                rightReloaded = false;
            }

        }

        if (Input.GetAxis("LeftReload") >= 0.5)
        {
            left1 = true;
        }
        if (Input.GetAxis("LeftReload") <= -0.5)
        {
            left2 = true;
        }

        if (Input.GetAxis("RightReload") >= 0.5)
        {
            right1 = true;
        }
        if (Input.GetAxis("RightReload") <= -0.5)
        {
            right2 = true;
        }

        if (left1 == true && left2 == true)
        {
            leftReloaded = true;
            left1 = false;
            left2 = false;
        }

        if (right1 == true && right2 == true)
        {
            rightReloaded = true;
            right1 = true;
            right2 = true;
        }
    }
}

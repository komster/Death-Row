using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Cannons : MonoBehaviour
{
    public AudioSource shot;
    public GameObject cannonSmoke;

    public GameObject[] cannon;
    public GameObject cannonBall;

    public int cannonSpeed;
    public float relodSpeed;

    public Transform[] leftCannonsSpawnPoints;
    public Transform[] rightCannonsSpawnPoints;

    public Transform[] leftCannonAimPositions;
    public Transform[] rightCannonAimPositions;

    public Transform[] leftCannons;
    public Transform[] rightCannons;

    private float leftRelodTimer;
    private float rightRelodTimer;

    private int leftCannonsPositon = 0;
    private int rightCannonsPositon = 0;

    void Start()
    {
        shot = this.gameObject.GetComponent<AudioSource>();
        CS_Notify.Register(this,"ReloadUpgrade");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.A))
        {
            if (leftRelodTimer <= 0)
            {
                shot.Play();
                for (int index = 0; index < cannon.Length; index++)
                {
                    if (cannon[index].activeInHierarchy)
                    {
                        cannonBall.transform.position = new Vector3 (leftCannonsSpawnPoints[index].transform.position.x, leftCannonsSpawnPoints[index].transform.position.y,0);
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (leftCannons[index].transform.up * cannonSpeed);
                        leftRelodTimer = relodSpeed;
                        Instantiate(cannonSmoke, leftCannonsSpawnPoints[index].transform.position, Quaternion.LookRotation(leftCannonAimPositions[index].transform.position - leftCannonsSpawnPoints[index].transform.position));
                    };
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            if (rightRelodTimer <= 0)
            {
                shot.Play();
                for (int index = 0; index < cannon.Length; index++)
                {
                    if (cannon[index].activeInHierarchy)
                    {
                        cannonBall.transform.position = new Vector3(rightCannonsSpawnPoints[index].transform.position.x, rightCannonsSpawnPoints[index].transform.position.y,0);
                        GameObject temp = Instantiate(cannonBall);
                        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();
                        rb.velocity = (rightCannons[index].transform.up * cannonSpeed);
                        rightRelodTimer = relodSpeed;
                        Instantiate(cannonSmoke, rightCannonsSpawnPoints[index].transform.position, Quaternion.LookRotation(rightCannonAimPositions[index].transform.position - rightCannonsSpawnPoints[index].transform.position));
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

    public void ReloadUpgrade()
    {
        relodSpeed -= 0.5f;
    }
}

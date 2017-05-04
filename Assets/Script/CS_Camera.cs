using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Camera : MonoBehaviour {

    public Camera main;
    public GameObject score;

    CS_Camera_Movment cameraScript;

    private bool zoomOut = false;
    private bool start = true;

    void Start () {
        CS_Notify.Register(this, "ChangeToArenaCamera");
        CS_Notify.Register(this, "ChangeToTravelCamera");
        cameraScript = main.GetComponent<CS_Camera_Movment>();
    }

    private void Update()
    {
        if (start == true)
        {         
            if (main.orthographicSize > 10)
            {
                main.orthographicSize = main.orthographicSize - 8* Time.deltaTime;
            }
            else
            {
                main.transform.position = Vector3.MoveTowards(main.transform.position, new Vector3(0,0,-10) ,Time.deltaTime * 8);
            }

            if (main.transform.position == new Vector3(0, 0, -10))
            {
                CS_Notify.Send(this, "StartGame");
                //CS_Notify.Send(this, "EnemyBoatStart");
                start = false;
            }
        }
        


        if (zoomOut == true)
        {          
            if (main.orthographicSize < 18)
            {
                main.orthographicSize = main.orthographicSize + 5 * Time.deltaTime;
            }
            else
            {
                zoomOut = false;
            }
        }
    }

    public void ChangeToArenaCamera()
    {
        main.transform.position = new Vector3(16.5f, 3, -10);
        zoomOut = true;
        cameraScript.gameStarted = false;
        cameraScript.enabled = false;

    }

    public void ChangeToTravelCamera()
    {
        start = true;
        cameraScript.enabled = true;
    }
}

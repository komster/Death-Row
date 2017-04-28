using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Camera : MonoBehaviour {

    public Camera main;

    public GameObject score;
    public GameObject score1;
    public GameObject text;

    private bool zoomOut = false;

    private bool start = true;

    private CS_Camera_Movment cameraScript;

    void Start () {
        CS_Notify.Register(this, "ChangeToArenaCamera");
        CS_Notify.Register(this, "ChangeToTravelCamera");
        cameraScript = GetComponent<CS_Camera_Movment>();
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
        zoomOut = true;
        CS_Notify.Send(this, "ChangeStage");
        score.SetActive(false);
        score1.SetActive(true);
        text.SetActive(true);
    }

    public void ChangeToTravelCamera()
    {

    }
}

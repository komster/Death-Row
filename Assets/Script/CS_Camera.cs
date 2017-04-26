using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Camera : MonoBehaviour {

    public Camera main;

    private bool zoomOut = false;
    private bool zoomIn = false;

    private bool start = true;



    void Start () {
        CS_Notify.Register(this, "ChangeToArenaCamera");
        CS_Notify.Register(this, "ChangeToTravelCamera");
        CS_Notify.Register(this, "ZoomOut");
        CS_Notify.Register(this, "StopZoomOut");
        CS_Notify.Register(this, "ZoomIn");
        CS_Notify.Register(this, "StopZoomIn");

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
            if (main.orthographicSize < 15)
            {
                main.orthographicSize = main.orthographicSize + 1 * Time.deltaTime;
            }
        }
        if (zoomIn == true )
        {
            if (main.orthographicSize > 7.5)
            {
                main.orthographicSize = main.orthographicSize - 1 * Time.deltaTime;
            }
        }
    }

    public void ChangeToArenaCamera()
    {

    }

    public void ChangeToTravelCamera()
    {

    }
    public void ZoomOut()
    {
        zoomOut = true;
    }
    public void StopZoomOut()
    {
        zoomOut = false;
    }
    public void ZoomIn()
    {
        zoomIn = true;
    }
    public void StopZoomIn()
    {
        zoomIn = false;
    }
}

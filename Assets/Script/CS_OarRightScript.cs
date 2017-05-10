using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_OarRightScript : MonoBehaviour {

    public bool upIsTheTarget;

    private Vector3 oarTargetAngle;


    private Vector3 oarCurrentAngle;


    // Use this for initialization
    void Start()
    {

        oarCurrentAngle = this.transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if (upIsTheTarget == true)
        {
            oarTargetAngle = new Vector3(0, 0, 40);
        }
        else
        {
            oarTargetAngle = new Vector3(0, 0, -40);
        }
        oarCurrentAngle = new Vector3(Mathf.LerpAngle(oarCurrentAngle.x, oarTargetAngle.x, Time.deltaTime * 3), Mathf.LerpAngle(oarCurrentAngle.y, oarTargetAngle.y, Time.deltaTime * 3), Mathf.LerpAngle(oarCurrentAngle.z, oarTargetAngle.z, Time.deltaTime * 3));


        transform.localEulerAngles = oarCurrentAngle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BoatTrail : MonoBehaviour {
    public TrailRenderer trail;
    // Use this for initialization
    void Start()
    {
        trail = this.GetComponent<TrailRenderer>();
        trail.sortingLayerName = "Background";
        trail.sortingOrder = -1;

    }

    // Update is called once per frame
    void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PrograssBar : MonoBehaviour {

    public Transform player;

    private Vector3 postion;

	void Start () {
        CS_Notify.Register(this, "NextTile");
        postion = player.position;
	}

    public void NextTile()
    {
        postion.y += 40;
        player.position = postion;
    }
}

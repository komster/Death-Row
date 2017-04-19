using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_GameManager_TileGenerator : MonoBehaviour {

    public CS_Tile_Generator generScript;

    private int level = 1;
    // Use this for initialization
    void Awake ()
    {
        generScript = GetComponent<CS_Tile_Generator>();
        InitGame();
	}
	void InitGame()
    {
        generScript.SetupWorld(level);
    }
	// Update is called once per frame
	void Update () {
		
	}
}

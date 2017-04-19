using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Tile_Generator : MonoBehaviour {

	

    public int columns = 3;
    public int rows = 5;
    public int numModules = 15;
    public int moduleWidth = 35;
    public int moduleHeight = 14;
    public List<GameObject> IslandsList = new List<GameObject>();
    
    

    public GameObject Tiles;

    public Transform tilePos;

    private void Start()
    {
        //Tiles = Resources.Load("Tile") as GameObject;


        InitTile();
        InitModule();
    }
    void Update()
    {
       
    }
    void InitTile()
    {
        Vector3 sP = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
       
         //Vector3 sP = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        
        Instantiate(Tiles, sP, Quaternion.identity);
    }
    void InitModule()
    {
        Vector3 tilePos = Tiles.transform.position;
        Vector3 sP = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        int rP = UnityEngine.Random.Range(0, IslandsList.Count);
        Instantiate(IslandsList[rP], tilePos, Quaternion.identity);
    }
   

    
}

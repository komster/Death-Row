using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Tile_Generator : MonoBehaviour {


    public List<GameObject> tilez = new List<GameObject>();
    
    public List<GameObject> IslandsList = new List<GameObject>();
    
    public GameObject Tiles;
    public Transform tilePos;
    public float playerMaxYPos;
    public GameObject player;
    public int newTilesToCreate = 5;
    private float newTilePosition = 0;
    private void Start()
    {
        //Tiles = Resources.Load("Tile") as GameObject;
        player = GameObject.Find("Player");
        Vector3 tilePos = Tiles.transform.position;
        InitTile();
        InitModule();
        playerMaxYPos = GameObject.Find("Player").transform.position.y;

    }
    void Update()
    {
       generateTiles();
    }
    public void generateTiles()
    {
        
        if(playerMaxYPos < GameObject.Find("Player").transform.position.y)
        {
            playerMaxYPos += 40;
            actuallyGeneratingTilesAgain();
        }
    }
    void actuallyGeneratingTilesAgain()
    {
        Vector3 yes = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, newTilePosition, 10));

        for(int i = 1; i <= newTilesToCreate; i++)
        {
            float fj = (i * 1.0f) + 14.0f;
            yes = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, newTilePosition + fj, 10));
            tilez.Add(Instantiate(Tiles, yes, Quaternion.identity));
            if(i == newTilesToCreate)
            {
                int hej = tilez.Count;
                float tempFloat = tilez[hej-1].transform.position.y;
                newTilePosition = tempFloat;
            }
        }
        //newTilePosition += 40;
    }
    void InitTile()
    {
        
        Vector3 sP = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));

        tilez.Add(Instantiate(Tiles, sP, Quaternion.identity));
        int hej = tilez.Count;
        float tempFloat = tilez[hej-1].transform.position.y;
        newTilePosition = tempFloat;


    }
    void InitModule()
    {
        Vector3 tilePos = Tiles.transform.position;
       
        int rP = UnityEngine.Random.Range(0, IslandsList.Count);
        Instantiate(IslandsList[rP], tilePos, Quaternion.identity);
    }
   

    
}

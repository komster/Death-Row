using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_World_Creater : MonoBehaviour {

    public GameObject[] moduals;
    public GameObject player;

    private List<Tiles> tiles = new List<Tiles>();

    private int startX = -105;
    private int startY = 0;

    private bool newTile = false;

    private float playerTileX;
    private float playerTileY;
    private int playerTile = 3;

    void Start() {
        RandomTiles(startX, startY);
        Instantiate(moduals[tiles[3].modual], new Vector3(tiles[3].posX, tiles[3].posY, 0f), new Quaternion());
        tiles[3].hasSpawned = true;
        playerTileX = 0;
        playerTileY = 0;
    }

    void Update() {

        if (player.transform.position.x > playerTileX + 15)
        {
            playerTileX += 30;
            if (tiles[playerTile + 1].hasSpawned == false)
            {
                playerTile += 1;
                Instantiate(moduals[tiles[playerTile].modual], new Vector3(tiles[playerTile].posX, tiles[playerTile].posY, 0f), new Quaternion());
                tiles[playerTile].hasSpawned = true;

            }
        }
        if (player.transform.position.x < playerTileX - 15)
        {
            playerTileX -= 30;
            if (tiles[playerTile -1].hasSpawned == false)
            {
                playerTile -=1;
                Instantiate(moduals[tiles[playerTile].modual], new Vector3(tiles[playerTile].posX, tiles[playerTile].posY, 0f), new Quaternion());
                tiles[playerTile].hasSpawned = true;

            }
        }
        if (player.transform.position.y > playerTileY + 15)
        {
            playerTileY += 30;

            if (tiles[playerTile + 7].hasSpawned == false)
            {
                playerTile += 7;
                Instantiate(moduals[tiles[playerTile].modual], new Vector3(tiles[playerTile].posX, tiles[playerTile].posY, 0f), new Quaternion());
                tiles[playerTile].hasSpawned = true;
    
            }
        }
        if (player.transform.position.y < playerTileY - 15)
        {
            playerTileY -= 30;
            if (tiles[playerTile - 7].hasSpawned == false)
            {
                playerTile -= 7;
                Instantiate(moduals[tiles[playerTile].modual], new Vector3(tiles[playerTile].posX, tiles[playerTile].posY, 0f), new Quaternion());
                tiles[playerTile].hasSpawned = true;

            }
        }
    }

    public void RandomTiles(int x, int y)
    {
        int changeLine = 0;
        for (int index = 0; index < 70; index++)
        {
            tiles.Add(new Tiles(Random.Range(0, moduals.Length), x, y));
            x += 35;
            changeLine++;
            if (changeLine == 7)
            {
                changeLine = 0;
                x = startX;
                y += 35;
            }

        }
    }


    private class Tiles
    {
        public int modual = 0;
        public float posX = 0;
        public float posY = 0;
        public bool hasSpawned = false;

        public Tiles(int mod, float x, float y)
        {
            modual = mod;
            posX = x;
            posY = y;
        }

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_World_Creater : MonoBehaviour {

    public GameObject[] moduals;
    public GameObject player;
    public GameObject emptyWater;
    public GameObject endTile;
    public GameObject startTile;

    private List<Lines> lines = new List<Lines>();

    private int line = 0;
    private int tile = 0;

    private float playerTileX = 0;
    private float playerTileY = 0;

    private int lineIndex = 0;

    private bool startSpawnTile = false;

    void Start() {

        addLine(line);
        addLine(line + 1);
        addLine(line - 1);

    }

    void Update() {

        if (player.transform.position.y >= 100 && startSpawnTile == false)
        {
            playerTileY = player.transform.position.y;
            startSpawnTile = true;
            CS_Notify.Send(this, "StartTimer");
        }
        if (startSpawnTile == true)
        {
            if (player.transform.position.x > playerTileX + 5)
            {
                if (checkLine(line + 2) == false)
                {
                    addLine(line + 2);
                    lineIndex++;
                    instansModuals(lineIndex, tile - 2, tile + 2);
                }
            }
            if (player.transform.position.x > playerTileX + 15)
            {
                line++;
                playerTileX += 25.5f;
                if (tile >= 0 && tile <= 14)
                {
                    if (lines[getLinePlace(line + 1)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line + 1), tile - 2, tile + 2);
                        instansModuals(getLinePlace(line + 2), tile - 2, tile + 2);
                    }
                }

            }
            if (player.transform.position.x < playerTileX - 5)
            {
                if (checkLine(line - 2) == false)
                {
                    addLine(line - 2);
                    lineIndex++;
                    instansModuals(lineIndex, tile - 2, tile + 2);
                }
            }
            if (player.transform.position.x < playerTileX - 15)
            {
                line--;
                playerTileX -= 25.5f;
                if (tile >= 0 && tile <= 14)
                {
                    if (lines[getLinePlace(line - 1)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line - 1), tile - 2, tile + 2);
                        instansModuals(getLinePlace(line - 2), tile - 2, tile + 2);
                    }
                }

            }
            if (player.transform.position.y > playerTileY + 5)
            {
                playerTileY += 25.5f;

                instansModuals(getLinePlace(line), tile, tile + 2);
                instansModuals(getLinePlace(line + 1), tile, tile + 2);
                instansModuals(getLinePlace(line - 1), tile, tile + 2);
                instansModuals(getLinePlace(line + 2), tile, tile + 2);
                instansModuals(getLinePlace(line - 2), tile, tile + 2);
                tile++;
                CS_Notify.Send(this, "NextTile");

                if (tile >= 0 && tile <= 14)
                {

                    if (lines[getLinePlace(line)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line), tile, tile + 2);
                    }
                    if (lines[getLinePlace(line + 1)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line + 1), tile, tile + 2);
                    }
                    if (lines[getLinePlace(line - 1)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line - 1), tile, tile + 2);
                    }
                    if (lines[getLinePlace(line + 2)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line + 2), tile, tile + 2);
                    }
                    if (lines[getLinePlace(line - 2)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line - 2), tile, tile + 2);
                    }
                }

            }

            if (player.transform.position.y < playerTileY)
            {

                instansModuals(getLinePlace(line), tile, tile - 1);
                instansModuals(getLinePlace(line + 1), tile, tile - 1);
                instansModuals(getLinePlace(line - 1), tile, tile - 1);
                instansModuals(getLinePlace(line + 2), tile, tile - 1);
                instansModuals(getLinePlace(line - 2), tile, tile - 1);

                if (tile >= 0 && tile <= 14)
                {

                    if (lines[getLinePlace(line)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line), tile, tile - 1);
                    }
                    if (lines[getLinePlace(line + 1)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line + 1), tile, tile - 1);
                    }
                    if (lines[getLinePlace(line - 1)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line - 1), tile, tile - 1);
                    }
                    if (lines[getLinePlace(line + 2)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line + 2), tile, tile - 1);
                    }
                    if (lines[getLinePlace(line - 2)].GetHasSpawned(tile) == false)
                    {
                        instansModuals(getLinePlace(line - 2), tile, tile - 1);
                    }
                }

            }
            if (tile > 0 && tile < 14)
            {
                if (lines[getLinePlace(line)].GetHasSpawned(tile - 1) == false)
                {
                    instansModuals(getLinePlace(line), tile, tile - 1);
                }
                if (lines[getLinePlace(line)].GetHasSpawned(tile) == false)
                {
                    instansModuals(getLinePlace(line), tile, tile - 1);
                }
                if (lines[getLinePlace(line)].GetHasSpawned(tile + 1) == false)
                {
                    instansModuals(getLinePlace(line), tile, tile + 1);
                }
                if (lines[getLinePlace(line)].GetHasSpawned(tile - 1) == false)
                {
                    instansModuals(getLinePlace(line), tile, tile + 1);
                }


                if (lines[getLinePlace(line + 1)].GetHasSpawned(tile - 2) == false)
                {
                    instansModuals(getLinePlace(line + 1), tile - 1, tile - 2);
                }
                if (lines[getLinePlace(line + 1)].GetHasSpawned(tile - 1) == false)
                {
                    instansModuals(getLinePlace(line + 1), tile, tile - 1);
                }
                if (lines[getLinePlace(line + 1)].GetHasSpawned(tile) == false)
                {
                    instansModuals(getLinePlace(line + 1), tile, tile);
                }
                if (lines[getLinePlace(line + 1)].GetHasSpawned(tile + 1) == false)
                {
                    instansModuals(getLinePlace(line + 1), tile, tile + 1);
                }
                if (lines[getLinePlace(line + 1)].GetHasSpawned(tile + 2) == false)
                {
                    instansModuals(getLinePlace(line + 1), tile + 1, tile + 2);
                }

                if (lines[getLinePlace(line - 1)].GetHasSpawned(tile - 2) == false)
                {
                    instansModuals(getLinePlace(line- 1), tile - 1, tile - 2);
                }
                if (lines[getLinePlace(line - 1)].GetHasSpawned(tile - 1) == false)
                {
                    instansModuals(getLinePlace(line - 1), tile, tile - 1);
                }
                if (lines[getLinePlace(line - 1)].GetHasSpawned(tile) == false)
                {
                    instansModuals(getLinePlace(line -1), tile, tile);
                }
                if (lines[getLinePlace(line - 1)].GetHasSpawned(tile + 1) == false)
                {
                    instansModuals(getLinePlace(line - 1), tile, tile + 1);
                }
                if (lines[getLinePlace(line - 1)].GetHasSpawned(tile + 2) == false)
                {
                    instansModuals(getLinePlace(line - 1), tile + 1, tile + 2);
                }
            }
           

            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                for (int tileIndex = 0; tileIndex < lines[lineIndex].tiles.Count; tileIndex++)
                {
                    if (player.transform.position.y >= lines[lineIndex].GetPosY(tileIndex) + 40)
                    {
                        Destroy(lines[lineIndex].tiles[tileIndex].tile);
                        lines[lineIndex].tiles[tileIndex].hasSpawned = false;
                    }
                }
            }

            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                for (int tileIndex = 0; tileIndex < lines[lineIndex].tiles.Count; tileIndex++)
                {
                    if (player.transform.position.x >= lines[lineIndex].GetPosX(tileIndex) + 50 || player.transform.position.x <= lines[lineIndex].GetPosX(tileIndex) - 50)
                    {
                        Destroy(lines[lineIndex].tiles[tileIndex].tile);
                        lines[lineIndex].tiles[tileIndex].hasSpawned = false;
                    }
                }
            }

            if (player.transform.position.y >= 180)
            {
                Destroy(startTile.gameObject);
            }
        }

    }

    public void addLine(int newLine)
    {
        lines.Add(new Lines(newLine,moduals.Length));
    }

    public bool checkLine(int value)
    {
        for (int index = 0; index < lines.Count; index++)
        {
            if (lines[index].line == value)
            {
                return true;
            }
        }
        return false;
    }

    public void instansModuals(int lineIndex, int startY, int stopY)
    {
        for (int tileIndex = startY; tileIndex < stopY; tileIndex++)
        {
            if (tileIndex >= 0 && tileIndex <= 14)
            {
                if (lines[lineIndex].GetHasSpawned(tileIndex) == false)
                {
                    if (lines[lineIndex].GetModual(tileIndex) == 200)
                    {
                        lines[lineIndex].tiles[tileIndex].tile = Instantiate(endTile, new Vector3(lines[lineIndex].GetPosX(tileIndex), lines[lineIndex].GetPosY(tileIndex)), Quaternion.identity);
                        lines[lineIndex].tiles[tileIndex].hasSpawned = true;
                    }
                    else
                    {
                        lines[lineIndex].tiles[tileIndex].tile = Instantiate(moduals[lines[lineIndex].GetModual(tileIndex)], new Vector3(lines[lineIndex].GetPosX(tileIndex), lines[lineIndex].GetPosY(tileIndex)), Quaternion.identity);
                        lines[lineIndex].tiles[tileIndex].hasSpawned = true;
                    }            
                }
                
            }
            
        }
    }

    public int getLinePlace(int value)
    {
        for (int index = 0; index < lines.Count; index++)
        {
            if (lines[index].line == value)
            {
                return index;
            }
        }

        return 0;
    }

    private class Lines
    {
        public int line;

        public List<Tiles> tiles = new List<Tiles>();

        public Lines(int lineIndex, int modualsLenght)
        {
            line = lineIndex;
            RandomTiles(line * 25.5f,modualsLenght, line);
        }


        public void RandomTiles(float x, int modualsLength, int line)
        {
            float y = 132;
            for (int index = 0; index < 15; index++)
            {
                if (index == 14)
                {
                    tiles.Add(new Tiles(200, x, y));
                }
                else
                {
                    tiles.Add(new Tiles(Random.Range(0, modualsLength), x, y));
                }
                
                y += 25.5f;

            }
        }

        public int GetModual(int index)
        {
            return tiles[index].modual;
        }
        public float GetPosX(int index)
        {
            return tiles[index].posX;
        }
        public float GetPosY(int index)
        {
            return tiles[index].posY;
        }
        public bool GetHasSpawned(int index)
        {
            if (index >=0)
            {
                return tiles[index].hasSpawned;
            }
            else
            {
                return true;
            }

        }


    }


    private class Tiles
    {
        public GameObject tile;
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



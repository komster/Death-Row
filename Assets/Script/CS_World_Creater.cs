using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_World_Creater : MonoBehaviour {

    public GameObject[] moduals;
    public GameObject player;
    public GameObject enemy;

    private List<Lines> lines = new List<Lines>();

    private int x = 0;
    private int y = 0;

    private int line = 0;
    private int tile = 0;

    private int playerTileX = 0;
    private int playerTileY = 0;

    private int lineIndex = 0;

    void Start() {

        addLine(line);
        instansModuals(lineIndex,0,2);
        addLine(line + 1);
        lineIndex++;
        instansModuals(lineIndex, 0, 2);
        addLine(line - 1);
        lineIndex++;
        instansModuals(lineIndex, 0, 2);
    }

    void Update() {

        if (player.transform.position.x > playerTileX + 15)
        {
            if (checkLine(line + 2) == false)
            {
                addLine(line + 2);
                lineIndex++;
                instansModuals(lineIndex, tile - 1, tile + 2);
            }
        }
        if (player.transform.position.x > playerTileX + 17)
        {
            line++;
            playerTileX += 30;
        }
        if (player.transform.position.x < playerTileX - 15)
        {
            if (checkLine(line -2 ) == false)
            {
                addLine(line - 2);
                lineIndex++;
                instansModuals(lineIndex, tile - 1, tile + 2);
            }
        }
        if (player.transform.position.x < playerTileX - 17)
        {
            line--;
            playerTileX -= 30;
        }
        if (player.transform.position.y > playerTileY + 17)
        {
            playerTileY += 30;
            instansModuals(getLinePlace(line), tile + 2, tile + 3);
            instansModuals(getLinePlace(line + 1), tile + 2, tile + 3);
            instansModuals(getLinePlace(line -1), tile + 2, tile + 3);
            tile++;
            if (lines[getLinePlace(line)].GetHasSpawned(tile) == false)
            {
                instansModuals(getLinePlace(line), tile, tile +1);
            }

        }
        if (player.transform.position.y < playerTileY - 17)
        {
            playerTileY -= 30;
            tile--;
        }

        for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
        {
            for (int tileIndex = 0; tileIndex < lines[lineIndex].tiles.Count; tileIndex++)
            {
                if (enemy.transform.position.y >= lines[lineIndex].GetPosY(tileIndex) + 17)
                {
                    Destroy(lines[lineIndex].tiles[tileIndex].tile);
                }
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
            if (tileIndex >= 0)
            {
                if (lines[lineIndex].GetHasSpawned(tileIndex) == false)
                {
                    lines[lineIndex].tiles[tileIndex].tile = Instantiate(moduals[lines[lineIndex].GetModual(tileIndex)], new Vector3(lines[lineIndex].GetPosX(tileIndex), lines[lineIndex].GetPosY(tileIndex)), Quaternion.identity);
                    lines[lineIndex].tiles[tileIndex].hasSpawned = true;
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
            RandomTiles(line * 36,modualsLenght);
        }


        public void RandomTiles(int x, int modualsLength)
        {
            float y = 0;
            for (int index = 0; index < 20; index++)
            {
                tiles.Add(new Tiles(Random.Range(0, modualsLength), x, y));
                y += 36;

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
            return tiles[index].hasSpawned;
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



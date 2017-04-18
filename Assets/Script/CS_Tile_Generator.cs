using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Tile_Generator : MonoBehaviour {

	[SerializeField]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 3;
    public int rows = 5;
    public GameObject[] IslandsModules;

    private Transform holder;
    private List<Vector3> tilePositions = new List<Vector3>();

    void InitList()
    {
        tilePositions.Clear();
        for(int x = 1; x < columns - 1; x++)
        {
            for (int y = -1; y < rows - 1; y++)
            {
                tilePositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void SetupTiles()
    {
        holder = new GameObject("Holder").transform;
        for (int x = 1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = IslandsModules[Random.Range(0, IslandsModules.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(holder);
            }
        }
    }
    

    public void SetupWorld(int level)
    {
        SetupTiles();
        InitList();

    }
}

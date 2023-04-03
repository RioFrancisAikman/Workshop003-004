using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTerrainScript : MonoBehaviour
{
    public float[,] terrainHeightData;
    public int rowsandcolums = 0;
    public float refinement = 0f;
    public float multiplier = 0f;
    float perlinNoise = 0f;
    Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        terrainHeightData = new float[rowsandcolums, rowsandcolums];
        terrain = GetComponent<Terrain>();

        for(int i = 0; i < rowsandcolums; i++)
        {
            for (int j = 0; j < rowsandcolums; j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * refinement, j * refinement);
                terrainHeightData[i, j] = perlinNoise * multiplier;
            }
        }

        terrain.terrainData.SetHeights(100, 100, terrainHeightData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

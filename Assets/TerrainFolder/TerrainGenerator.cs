using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public int depth = 20;
    private Terrain terrain;

    public float scale = 20;
    public float offsetX = 20f;
    public float offsetY = 20f;


    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();

        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, depth];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < depth; y++)
            {
                {
                    heights[x, y] = CalculateHeight(x,y);
                }
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y )
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)x / depth * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}

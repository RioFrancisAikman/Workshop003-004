using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{

   public GameObject wallPrefab;
    public int mazeSize = 15;
    public float perlinThreshold = 0.5f;

    public float startPointThreshold = 0.1f;
    public float endPointThreshold = 0.9f;

    public float i;
    public float j;

    public MazeGenerator mazeGenerator;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < mazeSize; i++)
       {
          i = i + 1;
       }
       for (int j = 0; j < mazeSize; j++)
       {
           j = j + 1;
       }

        GameObject newWall = Instantiate(wallPrefab, new Vector3(i, 0, j), Quaternion.identity);
        newWall.transform.parent = transform;

        float perlinValue = Mathf.PerlinNoise(i / (float)mazeSize, j / (float)mazeSize);

        if (perlinValue > perlinThreshold)
        {
          //  GameObject newWall = Instantiate(wallPrefab, new Vector3(i, 0, j), Quaternion.identity);
          //  newWall.transform.parent = transform;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

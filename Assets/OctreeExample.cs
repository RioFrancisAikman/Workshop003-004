using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctreeExample : MonoBehaviour
{
    public GameObject prefab;
    public int numbObjects = 100;
    public int maxDepth = 5;

    private Tree octree;
    private List<GameObject> objects;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < numbObjects; i++)
        {
          //  Vector3 position = new Vector3(Random.Range(-10f, 10f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

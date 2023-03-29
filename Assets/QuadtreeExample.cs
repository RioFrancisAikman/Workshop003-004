using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadtreeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class QuadtreeNode
    {
        public Rect bounds;
        public List<GameObject> objects;
        public QuadtreeNode[] children;
        
    }

    public class Quadtree
    {
        public QuadtreeNode root;
        public int maxObjectsPerNode;
        public int maxDepth;
    }
}

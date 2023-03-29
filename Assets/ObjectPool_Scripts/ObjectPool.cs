using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> bullets;
    public int numBullets;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        bullets = new List<GameObject>();

        for (int i = 0; i < numBullets; i++)
        {
            GameObject obj = new GameObject("Bullet_"+ i);
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }
}

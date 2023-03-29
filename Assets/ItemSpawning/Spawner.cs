using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public int numSpawns = 3;

    public int itemX = 2;
    public int itemY = 2;
    public int itemZ = 2;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numSpawns; i++)
        {
            SpawnItem();
        }
    }

   void SpawnItem()
    {
        Vector3 randomPos = new Vector3(Random.Range(-itemX, itemX), Random.Range(-itemY, itemY), Random.Range(-itemZ, itemZ));

        GameObject clone = Instantiate(itemToSpawn, randomPos, Quaternion.identity);
    }
}

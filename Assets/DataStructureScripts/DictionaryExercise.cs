using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryExercise : MonoBehaviour
{

    Dictionary<string, int> ages = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        ages.Add("John", 25);
        ages.Add("Mary", 30);
        ages.Add("Bob", 35);

        int maryAge = ages["Mary"];
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<string, int> pair in ages)
        {
            Debug.Log(pair.Key + ": " + pair.Value);
        }
    }
}

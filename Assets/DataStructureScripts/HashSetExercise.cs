using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashSetExercise : MonoBehaviour
{

    HashSet<string> words = new HashSet<string>();

    // Start is called before the first frame update
    void Start()
    {
        words.Add("apple");
        words.Add("banana");
        words.Add("orange");
    }

    // Update is called once per frame
    void Update()
    {
        if (words.Contains("banana"))
        {
            Debug.Log("Found banana");
        }

        foreach (string word in words)
        {
            Debug.Log(word);
        }
    }
}

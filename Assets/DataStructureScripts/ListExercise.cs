using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExercise : MonoBehaviour
{
    
    List<int> numbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }
    }
}

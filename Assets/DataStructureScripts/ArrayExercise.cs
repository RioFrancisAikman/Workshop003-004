using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrayExercise : MonoBehaviour
{

    int[] numbers = new int[5];
    int[] numbersCopy = new int[] {10, 20, 30, 40, 50};

    // Start is called before the first frame update
    void Start()
    {
        numbers[0] = 10;
        numbers[1] = 20;
        numbers[2] = 30;
        numbers[3] = 40;
        numbers[4] = 50;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
        }

        if (numbers.SequenceEqual(numbersCopy))
        {
            Debug.Log("The arrays are equal");
        }
        else
        {
            Debug.Log("The arrays are not equal");
        }
    }
}

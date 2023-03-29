using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackExercise : MonoBehaviour
{

    Stack<string> history = new Stack<string>();

    // Start is called before the first frame update
    void Start()
    {
        history.Push("Page 1");
        history.Push("Page 2");
        history.Push("Page 3");
    }

    // Update is called once per frame
    void Update()
    {
        while (history.Count > 0)
        {
            string page = history.Pop();
            Debug.Log("Viewing page: " + page);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueExercise : MonoBehaviour
{

    Queue<string> actions = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        actions.Enqueue("Jump");
        actions.Enqueue("Shoot");
        actions.Enqueue("Dodge");
    }

    // Update is called once per frame
    void Update()
    {
        while (actions.Count > 0)
        {
            string action = actions.Dequeue();
            Debug.Log("Performing action: " + action);
        }
    }
}

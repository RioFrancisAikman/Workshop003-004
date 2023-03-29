using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScript : MonoBehaviour
{

    public Transform playerTransfer;
    public Transform gameObjectTransform;

    public float checkpoint1Distance = 10f;
    public float checkpoint2Distance = 5f;
    public float checkpoint3Distance = 1f;

    private bool passCheckpoint1 = false;
    private bool passCheckpoint2 = false;
    private bool passCheckpoint3 = false;

    public MeshRenderer gameObjectRenderer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObjectTransform.position, playerTransfer.position);
        Debug.Log("Distance between player and game object " + distance);

        if (distance <= checkpoint1Distance && !passCheckpoint1)
        {
            Debug.Log("Player at checkpoint 1");
            passCheckpoint1 = true;
            gameObjectRenderer.material = Resources.Load<Material>("Cylinder Material");
        }

        if (distance <= checkpoint2Distance && !passCheckpoint2)
        {
            Debug.Log("Player at checkpoint 2");
            passCheckpoint2 = true;
            gameObjectRenderer.material = Resources.Load<Material>("Capsule Material");
        }

        if (distance <= checkpoint3Distance && !passCheckpoint3)
        {
            Debug.Log("Player at checkpoint 3");
            passCheckpoint3 = true;
            gameObjectRenderer.material = Resources.Load<Material>("Cube Material");
        }
    }
}

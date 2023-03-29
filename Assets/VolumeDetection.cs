using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDetection : MonoBehaviour
{
     public Material on, off;
    Renderer r;
    public bool playerInsideVolume;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("I SEE YOOOU!!!");
            playerInsideVolume = true;
            r.material = on;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Where did you go!?");
            playerInsideVolume = false;
            r.material = off;
        }
    }
}

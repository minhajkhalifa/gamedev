using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCounter : MonoBehaviour
{
    //internal static int waypointIterator = 0;
    internal static Transform boxTransform;
    private GameObject car;

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boxTransform = transform;
        }
    }
}

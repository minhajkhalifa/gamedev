using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCounter : MonoBehaviour {
    internal static int waypointIterator = 0;

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            waypointIterator++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

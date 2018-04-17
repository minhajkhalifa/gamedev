using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCounterSplitScreen : MonoBehaviour {
    internal static Transform boxTransform1;
    internal static Transform boxTransform2;
    //public GameObject car1;
    //public GameObject car2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boxTransform1 = transform;
        }
        else if (other.tag == "Player2")
        {
            boxTransform2 = transform;
        }
    }
}

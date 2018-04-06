using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        var carRB = other.transform.parent.parent.GetComponent<Rigidbody>();
        var vehicle = other.transform.parent.parent;
        vehicle.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 500, ForceMode.Acceleration);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

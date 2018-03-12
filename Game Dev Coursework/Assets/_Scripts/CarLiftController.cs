using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLiftController : MonoBehaviour {

    public GameObject gameObject;
    float angle = 360.0f;
    float time = 1.0f;
    Vector3 axis = Vector3.up;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.RotateAround(Vector3.zero, axis, angle * Time.deltaTime / time);
    }
}

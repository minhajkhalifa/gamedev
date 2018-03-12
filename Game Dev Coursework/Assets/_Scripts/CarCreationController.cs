using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarCreationController : MonoBehaviour {

    public GameObject[] cars;
    public int carCounter;
    public int selectedCar; //Set selected car

	// Use this for initialization
	void Start () {
        carCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cars[carCounter].SetActive(false);
            carCounter++;
            if (carCounter >= cars.Length)
            {
                carCounter = 0;
            }
            cars[carCounter].SetActive(true);

            //PlayerPrefs.SetInt("CarSelection", carCounter);

        }
	}
}

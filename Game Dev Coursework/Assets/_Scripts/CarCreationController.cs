using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class CarCreationController : MonoBehaviour {

    public GameObject[] cars;
    public int carCounter;
    public static int selectedCar; //Set selected car

	// Use this for initialization
	void Start () {
        carCounter = 0;
	}

    public void OnButtonClick()
    {
        SceneManager.LoadSceneAsync(Globals.GAME_SCENE);
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
            selectedCar = carCounter;
            cars[carCounter].SetActive(true);
        }
	}
}

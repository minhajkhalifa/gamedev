using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarChoice : MonoBehaviour
{
    public GameObject car;
    public GameObject car2;
    public int carChoice;
    // Use this for initialization
    void Start()
    {
        carChoice = CarCreationController.selectedCar;
        if (carChoice == 0)
        {
            car.SetActive(true);
        }
        else if (carChoice == 1)
        {
            car2.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    //public Transform[] waypointRespawn;
    private GameObject car;
    //internal static Transform[] waypoints;

    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        car = PlayerCarChoice.playerCar;

        if (Input.GetMouseButtonDown(0))
        {
            car.transform.position = RespawnCounter.boxTransform.position;
        }

    }
}

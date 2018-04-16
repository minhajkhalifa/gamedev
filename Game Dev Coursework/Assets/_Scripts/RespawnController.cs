using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Transform[] waypointRespawn;
    private GameObject car;
    internal static Transform[] waypoints;

    // Use this for initialization
    void Start()
    {
        waypoints = waypointRespawn;
    }


    // Update is called once per frame
    void Update()
    {
        car = PlayerCarChoice.playerCar;

        if (Input.GetMouseButtonDown(0))
        {
            //Destroy(car);
            //car = PlayerCarChoice.playerCar;
            //Instantiate(car, waypointRespawn[waypointIterator].transform);
            car.transform.position = waypoints[RespawnCounter.waypointIterator].transform.position;
        }

    }
}

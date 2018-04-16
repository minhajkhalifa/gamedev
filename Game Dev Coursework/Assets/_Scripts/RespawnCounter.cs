using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCounter : MonoBehaviour
{
    internal static int waypointIterator = 0;

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {

        //for (int i = 0; i < RespawnController.waypoints.Length; i++)
        //{
        if (other.tag == "Player" && RespawnController.waypoints[waypointIterator].name == ("RespawnPoint" + waypointIterator.ToString()))
        {
            waypointIterator++;
            //i++;
        }
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}

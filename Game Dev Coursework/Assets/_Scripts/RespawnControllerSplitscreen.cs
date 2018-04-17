using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnControllerSplitscreen : MonoBehaviour {
    public GameObject car1;
    public GameObject car2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //car = PlayerCarChoice.playerCar;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            car1.transform.position = RespawnCounterSplitScreen.boxTransform1.position;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            car2.transform.position = RespawnCounterSplitScreen.boxTransform2.position;
        }
    }
}

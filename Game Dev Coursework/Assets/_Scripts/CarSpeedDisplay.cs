using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpeedDisplay : MonoBehaviour {
    public Text carSpeed;
    private GameObject playerCar;
    private Rigidbody carRB;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerCar = PlayerCarChoice.playerCar;
        carRB = playerCar.GetComponent<Rigidbody>();

        double mph = carRB.velocity.magnitude * 2.237;

        carSpeed.text = string.Format("{0}", mph.ToString("N0"));
    }
}

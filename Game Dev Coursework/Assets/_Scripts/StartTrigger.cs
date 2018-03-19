﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartTrigger : MonoBehaviour
{
    public static int PlayerLapCounter = 1;
    public static int AILapCounter = 1;

    public Text lapTime;
    public Text bestLapScore;
    //int PlayerLap = PlayerLapCounter;
    //int AILap = AILapCounter;

    public GameObject playerCar;
    public GameObject aiCar;

    private void Start()
    {
        playerCar = PlayerCarChoice.playerCar;
    }

    void OnTriggerEnter(Collider other)
    {
        if ("lapTime < bestLap")
        {
            bestLapScore.text = lapTime.text;
        }

        //PlayerBike LapCounter
        if (MidwayTrigger.midWayPlayer == PlayerLapCounter)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerLapCounter++;
                print("Current Lap Player:" + PlayerLapCounter);
            }
        }

        //AIBike LapCounter
        if (MidwayTrigger.midWayAI == AILapCounter)
        {
            if (other.gameObject.tag == "AI")
            {
                AILapCounter++;
                print("Current Lap AI:" + AILapCounter);
            }
        }

        //detects who won
        if (MidwayTrigger.midWayPlayer == 2 && PlayerLapCounter == 3)
        {
            SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
        }
        else
        {
            //
        }
    }
}

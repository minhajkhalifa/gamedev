using System;
using System.Collections;
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
    public Text lapNumber;

    public GameObject playerCar;
    public GameObject aiCar;

    private void Start()
    {
        PlayerLapCounter = 1;
        AILapCounter = 1;

        playerCar = PlayerCarChoice.playerCar;
        lapNumber.text = PlayerLapCounter.ToString() + "/2";
    }

    void OnTriggerEnter(Collider other)
    {
        //Player LapCounter
        if (MidwayTrigger.midWayPlayer == PlayerLapCounter)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerLapCounter++;
                print("Current Lap Player:" + PlayerLapCounter);
                lapNumber.text = PlayerLapCounter.ToString() + "/2";

                TimeSpan usersLap;
                TimeSpan.TryParse(lapTime.text, out usersLap);

                TimeSpan bestLapTime; 
                TimeSpan.TryParse(bestLapScore.text, out bestLapTime);

                if (usersLap < bestLapTime || bestLapScore.text == "00:00:000")
                {
                    bestLapScore.text = lapTime.text;
                    PlayerPrefs.SetString("bestLap", bestLapScore.text);
                    
                }
                LapTimeController.isNewLap = true;
            }
        }

        //AI LapCounter
        if (MidwayTrigger.midWayAI == AILapCounter)
        {
            if (other.gameObject.tag == "AI")
            {
                AILapCounter++;
                print("Current Lap AI:" + AILapCounter);
            }
        }

        //Detect who won
        if (MidwayTrigger.midWayPlayer == 2 && PlayerLapCounter == 3)
        {
            SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
        }
        else if (MidwayTrigger.midWayAI == 2 && AILapCounter == 3)
        {
            SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
        }
    }
}

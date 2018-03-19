using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTrigger : MonoBehaviour
{
    public static int PlayerLapCounter = 1;
    public static int AILapCounter = 1;

    int PlayerLap = PlayerLapCounter;
    int AILap = AILapCounter;

    public GameObject playerCar;
    public GameObject aiCar;

    private void Start()
    {
        playerCar = PlayerCarChoice.playerCar;
    }

    void OnTriggerEnter(Collider other)
    {
        //PlayerBike LapCounter
        if (MidwayTrigger.midWayPlayer == PlayerLapCounter)
        {
            if (other.gameObject == (playerCar))
            {
                PlayerLapCounter++;
                print("Current Lap Player:" + PlayerLapCounter);
            }
        }

        //AIBike LapCounter
        if (MidwayTrigger.midWayAI == AILapCounter)
        {
            if (other.gameObject == (aiCar))
            {
                AILapCounter++;
                print("Current Lap AI:" + AILapCounter);
            }
        }

        //detects who won
        if (MidwayTrigger.midWayPlayer == 2)
        {
            if (other.gameObject == (playerCar))
            {
                if (PlayerLap == 2)
                {
                    SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
                }

                else
                {
                    //
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidwayTriggerSplitScreen : MonoBehaviour
{
    public static int midWayPlayer = 0;
    public static int midWayPlayer2 = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //midWayPlayer++;
            //if (midWayPlayer > StartTrigger.PlayerLapCounter)
            //{
            midWayPlayer = StartTriggerSplitScreen.Player1LapCounter;
            print("Halfway Lap Player:" + midWayPlayer);
            //}
        }

        if (other.gameObject.tag == "Player2")
        {
            //midWayPlayer2++;
            //print("Halfway Lap AI:" + midWayPlayer2);
            //if (midWayPlayer2 > StartTriggerSplitScreen.Player2LapCounter)
            //{
            midWayPlayer2 = StartTriggerSplitScreen.Player2LapCounter;
            print("Halfway Lap Player 2:" + midWayPlayer2);
            //}
        }
    }
}

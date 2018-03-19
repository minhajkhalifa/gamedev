using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidwayTrigger : MonoBehaviour
{
    public static int midWayPlayer = 0;
    public static int midWayAI = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            midWayPlayer++;
            print("Halfway Lap Player:" + midWayPlayer);
            if (midWayPlayer > StartTrigger.PlayerLapCounter)
            {
                midWayPlayer = StartTrigger.PlayerLapCounter;
            }
        }

        if (other.gameObject.tag == "AI")
        {
            midWayAI++;
            print("Halfway Lap AI:" + midWayAI);
            if (midWayAI > StartTrigger.AILapCounter)
            {
                midWayAI = StartTrigger.AILapCounter;
            }
        }
    }
}

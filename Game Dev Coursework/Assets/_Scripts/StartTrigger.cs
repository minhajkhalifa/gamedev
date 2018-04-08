using System;
using System.Collections;
using System.Globalization;
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
    public Text playerWon;

    public GameObject playerCar;
    public GameObject aiCar;

    private void Start()
    {
        PlayerLapCounter = 1;
        AILapCounter = 1;

        lapNumber.text = PlayerLapCounter.ToString() + "/2";
    }

    private void Update()
    {
        playerCar = PlayerCarChoice.playerCar;
    }

    void OnTriggerEnter(Collider other)
    {
        //Player Lap Count
        if (MidwayTrigger.midWayPlayer == PlayerLapCounter)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerLapCounter++;
                print("Current Lap Player:" + PlayerLapCounter);
                lapNumber.text = PlayerLapCounter.ToString() + "/2";

                //TimeSpan usersLap;
                //TimeSpan.TryParse(lapTime.text, out usersLap);
                TimeSpan userLap = TimeSpan.ParseExact(lapTime.text, @"m\:s\:fff", CultureInfo.InvariantCulture);

                TimeSpan bestLap = TimeSpan.ParseExact(bestLapScore.text, @"m\:s\:fff", CultureInfo.InvariantCulture);
                //TimeSpan bestLapTime; 
                //TimeSpan.TryParse(bestLapScore.text, out bestLapTime);

                if (userLap < bestLap || bestLapScore.text == "00:00:000")
                {
                    bestLapScore.text = lapTime.text;
                    PlayerPrefs.SetString("bestLap", bestLapScore.text);

                }
                LapTimeController.isNewLap = true;
            }
        }

        //AI Lap Count
        if (MidwayTrigger.midWayAI == AILapCounter)
        {
            if (other.gameObject.tag == "AI")
            {
                AILapCounter++;
                print("Current Lap AI:" + AILapCounter);
            }
        }

        //Detect who wins
        if (MidwayTrigger.midWayPlayer == 2 && PlayerLapCounter == 3) //PLAYER
        {
            playerWon.text = "PLAYER 1 WINS!";
            StartCoroutine(GoBackToMainMenu());

        }
        else if (MidwayTrigger.midWayAI == 2 && AILapCounter == 3) //AI
        {
            playerWon.text = "COMPUTER WINS!";
            StartCoroutine(GoBackToMainMenu());
        }
    }

    IEnumerator GoBackToMainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
    }
}

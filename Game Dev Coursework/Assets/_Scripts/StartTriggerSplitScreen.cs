using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartTriggerSplitScreen : MonoBehaviour
{
    public static int Player1LapCounter = 1;
    public static int Player2LapCounter = 1;

    public Text lapTime;
    public Text bestLapScore;
    public Text lapNumber;
    public Text playerWon;

    public Text lapTimeP2;
    public Text bestLapScoreP2;
    public Text lapNumberP2;
    public Text playerWonP2;

    public static bool isPlayer1;
    public static bool isPlayer2;

    //public GameObject playerCar;
    //public GameObject aiCar;

    private void Start()
    {
        Player1LapCounter = 1;
        Player2LapCounter = 1;

        lapNumber.text = Player1LapCounter.ToString() + "/2";
        lapNumberP2.text = Player2LapCounter.ToString() + "/2";
    }

    private void Update()
    {
        //playerCar = PlayerCarChoice.playerCar;
    }

    void OnTriggerEnter(Collider other)
    {
        //Player LapCounter
        if (MidwayTriggerSplitScreen.midWayPlayer == Player1LapCounter)
        {
            if (other.gameObject.tag == "Player")
            {
                Player1LapCounter++;
                print("Current Lap Player:" + Player1LapCounter);
                lapNumber.text = Player1LapCounter.ToString() + "/2";

                //TimeSpan usersLap;
                //TimeSpan.TryParse(lapTime.text, out usersLap);

                TimeSpan userLap = TimeSpan.ParseExact(lapTime.text, @"m\:s\:fff", CultureInfo.InvariantCulture);

                //TimeSpan bestLapTime;
                //TimeSpan.TryParse(bestLapScore.text, out bestLapTime);
                
                TimeSpan bestLap = TimeSpan.ParseExact(bestLapScore.text, @"m\:s\:fff", CultureInfo.InvariantCulture);

                if (userLap < bestLap || bestLapScore.text == "00:00:000")
                {
                    bestLapScore.text = lapTime.text;
                    PlayerPrefs.SetString("bestLap", bestLapScore.text);
                }

                isPlayer1 = true;
                LapTimeControllerSplitScreen.isNewLap = true;
            }
        }

        //Player2 LapCounter
        if (MidwayTriggerSplitScreen.midWayPlayer2 == Player2LapCounter)
        {
            if (other.gameObject.tag == "Player2")
            {
                Player2LapCounter++;
                print("Current Lap Player2:" + Player2LapCounter);
                lapNumberP2.text = Player2LapCounter.ToString() + "/2";

                //TimeSpan usersLap;
                //TimeSpan.TryParse(lapTimeP2.text, out usersLap);
                TimeSpan userLap = TimeSpan.ParseExact(lapTimeP2.text, @"m\:s\:fff", CultureInfo.InvariantCulture);

                TimeSpan bestLap = TimeSpan.ParseExact(bestLapScoreP2.text, @"m\:s\:fff", CultureInfo.InvariantCulture);
                //TimeSpan bestLapTime;
                //TimeSpan.TryParse(bestLapScoreP2.text, out bestLapTime);

                if (userLap < bestLap || bestLapScoreP2.text == "00:00:000")
                {
                    bestLapScoreP2.text = lapTimeP2.text;
                    PlayerPrefs.SetString("bestLap", bestLapScoreP2.text);

                }

                isPlayer2 = true;
                LapTimeControllerSplitScreen.isNewLap = true;
            }
        }

        //Detect who won
        if (MidwayTriggerSplitScreen.midWayPlayer == 2 && Player1LapCounter == 3)
        {
            playerWon.text = "PLAYER 1 WINS!";
            StartCoroutine(GoBackToMainMenu());
            
        }
        else if (MidwayTriggerSplitScreen.midWayPlayer2 == 2 && Player2LapCounter == 3)
        {
            playerWonP2.text = "PLAYER 2 WINS!";
            StartCoroutine(GoBackToMainMenu());
        }
    }

    IEnumerator GoBackToMainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
    }
}

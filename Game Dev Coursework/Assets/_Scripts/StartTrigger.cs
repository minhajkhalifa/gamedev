using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

    public Text highScore1;
    public Text highScore2;
    public Text highScore3;
    public Text highScore4;

    public GameObject panel;


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

                TimeSpan score1 = TimeSpan.ParseExact(highScore1.text, @"m\:s\:fff", CultureInfo.InvariantCulture);
                TimeSpan score2 = TimeSpan.ParseExact(highScore2.text, @"m\:s\:fff", CultureInfo.InvariantCulture);
                TimeSpan score3 = TimeSpan.ParseExact(highScore3.text, @"m\:s\:fff", CultureInfo.InvariantCulture);
                TimeSpan score4 = TimeSpan.ParseExact(highScore4.text, @"m\:s\:fff", CultureInfo.InvariantCulture);

                List<TimeSpan> scoreTimes = new List<TimeSpan>();
                scoreTimes.Add(score1);
                scoreTimes.Add(score2);
                scoreTimes.Add(score3);
                scoreTimes.Add(score4);

                //scoreTimes.OrderByDescending(x => x).ToList();

                List<Text> highScores = new List<Text>();
                highScores.Add(highScore1);
                highScores.Add(highScore2);
                highScores.Add(highScore3);
                highScores.Add(highScore4);

                foreach (var scoreTime in scoreTimes) //Get all scores (Time objects)
                {
                    if (userLap < scoreTime || scoreTime.ToString() == "00:00:00") //If BestLap is quicker than current Score
                    {
                        foreach (var highScore in highScores) //Get all text objects 
                        {
                            highScore.text = lapTime.text; //Set high score to match lap time
                        }
                    }
                }

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
            panel.SetActive(true);
            StartCoroutine(GoBackToMainMenu());

        }
        else if (MidwayTrigger.midWayAI == 2 && AILapCounter == 3) //AI
        {
            playerWon.text = "COMPUTER WINS!";
            panel.SetActive(true);
            StartCoroutine(GoBackToMainMenu());
        }
    }

    IEnumerator GoBackToMainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync(Globals.MENU_SCENE);
    }
}

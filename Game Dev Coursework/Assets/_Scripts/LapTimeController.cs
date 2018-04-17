using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class LapTimeController : MonoBehaviour
{

    public GameObject carControl;
    public GameObject carControl2;
    public Text lapTime;
    bool isGamePlaying;
    public Text startTimer;
    public int countDown = 3;
    public GameObject AICar;
    public Text bestLap;
    public AudioSource countdownAudio;
    public AudioSource gameAudio;

    private float timer = 0f;

    public static bool isNewLap = false;

    // Use this for initialization
    void Start()
    {
        countdownAudio.Play();

        CarUserControl carController = carControl.GetComponent<CarUserControl>();
        CarUserControl car2Controller = carControl2.GetComponent<CarUserControl>();
        if (carController != null)
        {
            carController.enabled = false;
        }

        CarUserControl1 carUserControl1 = carControl.GetComponent<CarUserControl1>();
        if (carUserControl1 != null)
        {
            carUserControl1.enabled = false;
        }

        car2Controller.enabled = false;
        CarAIControl AICarController = AICar.GetComponent<CarAIControl>();
        AICarController.enabled = false;

        startTimer.text = countDown.ToString();
        StartCoroutine(Countdown(countDown));

        if (PlayerPrefs.HasKey("bestLap"))
        {
            string bestLapScore = PlayerPrefs.GetString("bestLap");
            bestLap.text = bestLapScore;
        }
        else
        {
            bestLap.text = "00:00:000";
        }
    }

    private IEnumerator Countdown(int seconds)
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = seconds; i >= 0; i--)
        {
            if (i > 0)
            {
                startTimer.text = i.ToString();
                yield return new WaitForSeconds(0.75f);
            }
            else if (i <= 0)
            {
                startTimer.text = "GO";
                yield return new WaitForSeconds(1.0f);
                isGamePlaying = true;
            }
        }
        gameAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePlaying)
        {
            ReEnableControls();

            if (isNewLap == true)
            {
                timer = 0f;
                isNewLap = false;
            }

            timer += Time.deltaTime;

            float minuteLap = Mathf.FloorToInt(timer / 60f);
            float secondLap = Mathf.FloorToInt(timer - minuteLap * 60f);
            float milliSecondLap = Mathf.FloorToInt(timer * 1000f) % 1000;

            lapTime.text = string.Format("{0:00}:{1:00}:{2:000}", minuteLap, secondLap, milliSecondLap);
        }
    }

    private void ReEnableControls()
    {
        startTimer.text = "";
        CarUserControl carController = carControl.GetComponent<CarUserControl>();
        CarUserControl car2Controller = carControl2.GetComponent<CarUserControl>();
        if (carController != null)
        {
            carController.enabled = true;
        }

        CarUserControl1 carUserControl1 = carControl.GetComponent<CarUserControl1>();
        if (carUserControl1 != null)
        {
            carUserControl1.enabled = true;
        }
        
        car2Controller.enabled = true;
        CarAIControl AICarController = AICar.GetComponent<CarAIControl>();
        AICarController.enabled = true;
    }
}

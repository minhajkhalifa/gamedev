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
    public GameObject lapTiming;
    public Text lapTime;
    bool isGamePlaying;
    public Text startTimer;
    public int countDown = 3;
    public GameObject AICar;

    // Use this for initialization
    void Start()
    {
        //carControl.SetActive(false);
        CarController carController = carControl.GetComponent<CarController>();
        CarController car2Controller = carControl2.GetComponent<CarController>();
        carController.enabled = false;
        car2Controller.enabled = false;
        CarAIControl AICarController = AICar.GetComponent<CarAIControl>();
        AICarController.enabled = false;
        //carControl2.SetActive(false);
        lapTiming.SetActive(false);
        startTimer.text = countDown.ToString();
        StartCoroutine(Countdown(countDown));
    }

    private IEnumerator Countdown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            if (i > 0)
            {
                startTimer.text = i.ToString();
                yield return new WaitForSeconds(1.0f);
            }
            else if (i <= 0)
            {
                startTimer.text = "GO";
                yield return new WaitForSeconds(1.0f);
                isGamePlaying = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePlaying)
        {
            startTimer.text = "";
            CarController carController = carControl.GetComponent<CarController>();
            CarController car2Controller = carControl2.GetComponent<CarController>();
            carController.enabled = true;
            car2Controller.enabled = true;
            CarAIControl AICarController = AICar.GetComponent<CarAIControl>();
            AICarController.enabled = true;
            lapTiming.SetActive(true);
            int minutes = Mathf.FloorToInt(Time.timeSinceLevelLoad / 60);
            float seconds = Mathf.FloorToInt(Time.timeSinceLevelLoad % 60);
            float milliSeconds = Mathf.FloorToInt((Time.timeSinceLevelLoad * 10) % 99);

            lapTime.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
        }
    }
}

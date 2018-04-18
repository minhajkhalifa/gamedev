using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class LapTimeControllerSplitScreen : MonoBehaviour
{

    public GameObject carControl;
    public GameObject carControl2;
    public Text lapTimePlayer1;
    public Text lapTimePlayer2;
    bool isGamePlaying;
    public Text startTimerPlayer1;
    public Text startTimerPlayer2;
    public int countDown = 3;
    public GameObject AICar;
    public Text bestLapPlayer1;
    public Text bestLapPlayer2;
    public AudioSource countdownAudio;
    public AudioSource gameAudio;

    private float timer = 0f;
    private float timer2 = 0f;

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

        startTimerPlayer1.text = countDown.ToString();
        startTimerPlayer2.text = countDown.ToString();
        StartCoroutine(Countdown(countDown));

        if (PlayerPrefs.HasKey("bestLap"))
        {
            string bestLapScore = PlayerPrefs.GetString("bestLap");
            bestLapPlayer1.text = bestLapScore;
            bestLapPlayer2.text = bestLapScore;
        }
        else
        {
            bestLapPlayer1.text = "00:00:000";
            bestLapPlayer2.text = "00:00:000";
        }
    }

    private IEnumerator Countdown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            if (i > 0)
            {
                startTimerPlayer1.text = i.ToString();
                startTimerPlayer2.text = i.ToString();
                yield return new WaitForSeconds(1.0f);
            }
            else if (i <= 0)
            {
                startTimerPlayer1.text = "GO";
                startTimerPlayer2.text = "GO";
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

            if (isNewLap == true && StartTriggerSplitScreen.isPlayer1 == true)
            {
                timer = 0f;
                isNewLap = false;
                StartTriggerSplitScreen.isPlayer1 = false;
            }
            else if (isNewLap == true && StartTriggerSplitScreen.isPlayer2 == true)
            {
                timer2 = 0f;
                isNewLap = false;
                StartTriggerSplitScreen.isPlayer2 = false;
            }

            timer += Time.deltaTime;

            float minuteLap = Mathf.FloorToInt(timer / 60f);
            float secondLap = Mathf.FloorToInt(timer - minuteLap * 60f);
            float milliSecondLap = Mathf.FloorToInt(timer * 1000f) % 1000;

            lapTimePlayer1.text = string.Format("{0:00}:{1:00}:{2:000}", minuteLap, secondLap, milliSecondLap);

            timer2 += Time.deltaTime;

            float minuteLap2 = Mathf.FloorToInt(timer2 / 60f);
            float secondLap2 = Mathf.FloorToInt(timer2 - minuteLap2 * 60f);
            float milliSecondLap2 = Mathf.FloorToInt(timer2 * 1000f) % 1000;

            lapTimePlayer2.text = string.Format("{0:00}:{1:00}:{2:000}", minuteLap2, secondLap2, milliSecondLap2);
        }
    }

    private void ReEnableControls()
    {
        startTimerPlayer1.text = "";
        startTimerPlayer2.text = "";
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

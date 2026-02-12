using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    TextMeshProUGUI timerText;
    TextMeshProUGUI FinishedTime;
    public float TimeTaken;
    void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        FinishedTime = GameObject.Find("FinishTime").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu" && SceneManager.GetActiveScene().name != "Speedrun Final Time")
        {
            TimeTaken += Time.deltaTime;
            timerText.enabled = true;
            FinishedTime.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            timerText.enabled = false;
            FinishedTime.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Speedrun Final Time")
        {
            timerText.enabled = false;
            FinishedTime.enabled = true;
            FinishedTime.text = "Your Time: " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(TimeTaken / 60F), Mathf.FloorToInt(TimeTaken - (Mathf.FloorToInt(TimeTaken / 60F) * 60)));
        }

        int minutes = Mathf.FloorToInt(TimeTaken / 60F);
        int seconds = Mathf.FloorToInt(TimeTaken - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

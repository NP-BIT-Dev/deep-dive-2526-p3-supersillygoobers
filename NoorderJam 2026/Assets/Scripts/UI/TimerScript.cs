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
        if (SceneManager.GetActiveScene().name != "Main Menu" && SceneManager.GetActiveScene().name != "SpeedrunFinalTime")
        {
            TimeTaken += Time.deltaTime;
            timerText.enabled = true;
            FinishedTime.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            Destroy(GameObject.Find("Timer")); 
            Destroy(GameObject.Find("FinishTime"));
        }
        else if (SceneManager.GetActiveScene().name == "SpeedrunFinalTime")
        {
            timerText.enabled = false;
            FinishedTime.enabled = true;
        }

        int minutes = Mathf.FloorToInt(TimeTaken / 60F);
        int seconds = Mathf.FloorToInt(TimeTaken - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        FinishedTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

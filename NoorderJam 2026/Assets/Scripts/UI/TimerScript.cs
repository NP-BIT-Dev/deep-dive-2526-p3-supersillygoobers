using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    TextMeshProUGUI timerText;
    float TimeTaken;
    void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            TimeTaken += Time.deltaTime;
            timerText.enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            timerText.enabled = false;
        }

        int minutes = Mathf.FloorToInt(TimeTaken / 60F);
        int seconds = Mathf.FloorToInt(TimeTaken - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

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
        if (SceneManager.GetActiveScene().name != "Main Menu" || SceneManager.GetActiveScene().name != "Example 2")
        {
            TimeTaken += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(TimeTaken / 60F);
        int seconds = Mathf.FloorToInt(TimeTaken - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

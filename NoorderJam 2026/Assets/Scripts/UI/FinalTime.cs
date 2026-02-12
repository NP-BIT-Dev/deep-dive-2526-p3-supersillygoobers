using TMPro;
using UnityEngine;

public class FinalTime : MonoBehaviour
{
    TimerScript DurationOfRun;
    TextMeshProUGUI FinishedTime;
    void Start()
    {
        FinishedTime = GameObject.Find("FinishTime").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        int minutes = Mathf.FloorToInt(DurationOfRun.TimeTaken / 60F);
        int seconds = Mathf.FloorToInt(DurationOfRun.TimeTaken - minutes * 60);
        FinishedTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

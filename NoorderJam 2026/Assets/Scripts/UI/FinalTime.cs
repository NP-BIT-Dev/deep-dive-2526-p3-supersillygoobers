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
        FinishedTime.text = "Your Time: " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(DurationOfRun.TimeTaken / 60F), Mathf.FloorToInt(DurationOfRun.TimeTaken - (Mathf.FloorToInt(DurationOfRun.TimeTaken / 60F) * 60)));
    }
}

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

		Scene currentScene = SceneManager.GetActiveScene ();

		string sceneName = currentScene.name;

		if (sceneName == "Example 1") 
		{
			
		}
		else if (sceneName == "Example 2")
		{
			
		}
    }
    
    void Update()
    {
        TimeTaken += Time.deltaTime;
        int minutes = Mathf.FloorToInt(TimeTaken / 60F);
        int seconds = Mathf.FloorToInt(TimeTaken - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

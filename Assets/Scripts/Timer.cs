using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public static int minute;
	public static float seconds;

	private Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
		seconds = 0f;
        timerText = GetComponentInChildren<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
		if(seconds >= 60f) {
			minute++;
			seconds = seconds - 60;
		}

        timerText.text = minute.ToString("00") + ":" + ((int) seconds).ToString ("00");
    }
}

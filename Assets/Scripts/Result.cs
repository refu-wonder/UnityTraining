using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    private Text timerText;
    private Text bestTimeText;
    public static float bestSeconds = 99f;
    public static int bestMinute = 99;
    // Start is called before the first frame update
    void Start()
    {
        timerText = transform.GetChild(0).gameObject.GetComponent<Text>();
        bestTimeText = transform.GetChild(1).gameObject.GetComponent<Text>();
        if(Timer.minute <= Result.bestMinute && Timer.seconds <= Result.bestSeconds){
            Result.bestMinute = Timer.minute;
            Result.bestSeconds = Timer.seconds;
        }
        timerText.text = "Time:" + Timer.minute.ToString("00") + ":" + ((int) Timer.seconds).ToString ("00");
        bestTimeText.text = "BestTime:" + Result.bestMinute.ToString("00") + ":" + ((int) Result.bestSeconds).ToString ("00");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

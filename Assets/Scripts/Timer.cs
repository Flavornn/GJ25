using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float TimeLeft = 60.0f;
    private bool TimerOn = false;

    public Text TimerText;
    public void Start()
    {
        TimerOn = true;
    }

    public void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        }
        else 
        {
            timerEnded();
        }
        TimerUpdate(TimeLeft);
    }

    private void TimerUpdate(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{01:00}", seconds);
    }

    void timerEnded()
    {
        Debug.Log("Time is up!");
        TimeLeft = 0;
        TimerOn = false;
    }


}
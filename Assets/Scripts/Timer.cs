using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeLeft = 60.0f;
    private bool TimerOn = false;

    public Text TimerText;
    public RawImage ImageToShow;

    public void Start()
    {
        TimerOn = true;

        // Hide the image at the start
        if (ImageToShow != null)
        {
            ImageToShow.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            TimerUpdate(TimeLeft);
        }
        else
        {
            timerEnded();
        }
    }

    private void TimerUpdate(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void timerEnded()
    {
        Debug.Log("Time is up!");
        TimeLeft = 0;
        TimerOn = false;

        // Show the image and hide the timer text
        if (ImageToShow != null)
        {
            ImageToShow.gameObject.SetActive(true);
        }

        if (TimerText != null)
        {
            TimerText.gameObject.SetActive(false);
        }
    }
}

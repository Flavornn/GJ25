using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float TimeLeft = 60.0f;
    public bool TimerOn = false;

    public Text TimerText;
    public RawImage ImageToShow;
    public Button RestartButton;

    public void Start()
    {
        TimerOn = true;

        if (ImageToShow != null)
        {
            ImageToShow.gameObject.SetActive(false);
        }

        if (RestartButton != null)
        {
            RestartButton.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if (TimerOn && TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            TimerUpdate(TimeLeft);
        }
        else if (TimeLeft <= 0 && TimerOn)
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

    public void StopTimer()
    {
        TimerOn = false;
    }

    void timerEnded()
    {
        TimerOn = false;
        TimeLeft = 0;
        Debug.Log("Time is up!");

        if (TimerText != null)
        {
            TimerText.gameObject.SetActive(false);
        }

        if (ImageToShow != null)
        {
            ImageToShow.gameObject.SetActive(true);
        }

        if (RestartButton != null)
        {
            StartCoroutine(ShowRestartButton());
        }
    }

    IEnumerator ShowRestartButton()
    {
        yield return new WaitForSeconds(1f);

        if (RestartButton != null)
        {
            RestartButton.gameObject.SetActive(true);
        }
    }
}

public class GameRestart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

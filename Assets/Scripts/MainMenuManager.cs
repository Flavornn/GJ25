using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject buttonsToHide;
    public GameObject textToHide;
    public GameObject creditsObjects;
    private bool isCreditsActive = false;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }

        else
        {
            Application.Quit();
        }
        
    }

    public void ShowCredits()
    {
        if (!isCreditsActive) {
            buttonsToHide.SetActive(false);
            textToHide.SetActive(false);
            creditsObjects.SetActive(true);
            isCreditsActive = true;
        }
        else
        {
            buttonsToHide.SetActive(true);
            textToHide.SetActive(true);
            creditsObjects.SetActive(false);
            isCreditsActive = false;
        }
    }
}

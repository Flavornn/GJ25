using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [Header("Pipe Configuration")]
    [Tooltip("List of pipe objects and their correctness status")]
    public List<Pipe> pipes = new List<Pipe>();
    public WaterEnabler waterEnabler;
    private bool waterEnabled = false;

    private PipeAnimator pipeAnimator;
    private BubbleAnimator bubbleAnimator;

    public RawImage WinRawImage;
    public float toggleDelay = 2f;
    public Button WinButton;

    public Timer timer;

    void Start()
    {
        if (pipes.Count == 0)
        {
            Debug.LogWarning("No pipes assigned. Please assign valves in the Inspector.");
        }

        pipeAnimator = FindAnyObjectByType<PipeAnimator>();
        bubbleAnimator = FindAnyObjectByType<BubbleAnimator>();

        if (WinRawImage != null)
        {
            WinRawImage.enabled = false;
        }

        if (WinButton != null)
        {
            WinButton.gameObject.SetActive(false);
        }
    }

    public void CheckPipes()
    {
        bool allCorrect = true;

        foreach (var pipe in pipes)
        {
            if (pipe.currentState != pipe.correctState)
            {
                allCorrect = false;
                Debug.Log("Checking");
                break;
            }
        }

        if (allCorrect && !waterEnabled)
        {
            waterEnabled = true;
            Debug.Log("True");
            waterEnabler?.EnableWater();
            pipeAnimator?.PlayAnimation();
            bubbleAnimator?.PlayAnimation();

            if (timer != null)
            {
                timer.TimerOn = false;
            }

            StartCoroutine(ToggleImageWithDelay());
            StartCoroutine(ToggleButtonWithDelay());
        }
    }

    private IEnumerator ToggleImageWithDelay()
    {
        yield return new WaitForSeconds(toggleDelay);

        WinRawImage.enabled = true;
    }

    private IEnumerator ToggleButtonWithDelay()
    {
        yield return new WaitForSeconds(toggleDelay+1);

        WinButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        CheckPipes();
    }
}

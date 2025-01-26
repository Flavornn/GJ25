using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Pipe Configuration")]
    [Tooltip("List of pipe objects and their correctness status")]
    public List<Pipe> pipes = new List<Pipe>();
    public WaterEnabler waterEnabler;
    private bool waterEnabled = false;

    void Start()
    {
        if (pipes.Count == 0)
        {
            Debug.LogWarning("No pipes assigned. Please assign valves in the Inspector.");
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
                break;
            }
        }

        if (allCorrect && !waterEnabled)
        {
            waterEnabled = true;
            Debug.Log("True");
            waterEnabler?.EnableWater();
        }
    }

    private void Update()
    {
        CheckPipes();
    }
}

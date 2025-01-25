using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Pipe Configuration")]
    [Tooltip("List of pipe objects and their correctness status")]
    public List<Pipe> pipes = new List<Pipe>();

    void Start()
    {
        if (pipes.Count == 0)
        {
            Debug.LogWarning("No pipes assigned. Please assign valves in the Inspector.");
        }
    }

    public void CheckPipes()
    {
        /*int correctCount = 0;

        foreach (var pipe in pipes)
        {
            if (pipe.isCorrect)
            {
                correctCount++;
                Debug.Log($"{pipe.pipeObject.name} is correct.");
            }
            else
            {
                Debug.Log($"{pipe.pipeObject.name} is incorrect.");
            }
        }

        Debug.Log($"{correctCount}/{pipes.Count} valves are correct.");*/
        bool isCorrect = false;
        foreach (var pipe in pipes)
        {
            if (pipe.currentState == pipe.correctState)
            {
                isCorrect = true;
            }
            else {
                
                isCorrect = false; 
                break;
            }
        }

        Debug.Log(isCorrect);
    }

    private void Update()
    {
        CheckPipes();
    }
}

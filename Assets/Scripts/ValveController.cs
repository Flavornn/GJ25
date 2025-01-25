using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValveController : MonoBehaviour
{

    private bool isActivated;
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnMouseDown()
    {
        if ( !isActivated)
        {
            isActivated = true;
            //gameManager.CurrentTurns++;
        }
    }

    void Update()
    {
        
    }
}

using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int MaxTurns;
    [SerializeField] public int CurrentTurns;   
    [System.Serializable]
    public class Valve
    {
        public GameObject valveObject;
        public bool isCorrect;
    }

    [Tooltip("List of valve objects and their correctness status")]
    public List<Valve> valves = new List<Valve>();

    void Start()
    {
        if (valves.Count == 0)
        {
            Debug.LogWarning("No valves assigned. Please assign valves in the Inspector.");
        }
    }

    public void Update()
    {
        if(CurrentTurns > MaxTurns)
        {
            Debug.Log("You lost");
        }

        foreach (var valve in valves)
        {
            if (valve.isCorrect)
            {

                Debug.Log($"{valve.valveObject.name} is correct.");
            }
            else
            {
                Debug.Log($"{valve.valveObject.name} is incorrect.");
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ValveChecker : MonoBehaviour
{
    [System.Serializable]
    public class Valve
    {
        public GameObject valveObject;
        public bool isCorrect;
    }

    [Header("Valve Configuration")]
    [Tooltip("List of valve objects and their correctness status")]
    public List<Valve> valves = new List<Valve>();

    void Start()
    {
        if (valves.Count == 0)
        {
            Debug.LogWarning("No valves assigned. Please assign valves in the Inspector.");
        }
    }

    public void CheckValves()
    {
        int correctCount = 0;

        foreach (var valve in valves)
        {
            if (valve.isCorrect)
            {
                correctCount++;
                Debug.Log($"{valve.valveObject.name} is correct.");
            }
            else
            {
                Debug.Log($"{valve.valveObject.name} is incorrect.");
            }
        }

        Debug.Log($"{correctCount}/{valves.Count} valves are correct.");
    }
}

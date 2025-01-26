using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    private int enabledChildNumber = 0;
    public bool shouldEnable = true;
    private float timer = 0f;
    private float enablingSpeed = 0.5f;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
        transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldEnable && timer >= enabledChildNumber * enablingSpeed && enabledChildNumber < transform.childCount) {
            transform.GetChild(enabledChildNumber).gameObject.SetActive(true);
        enabledChildNumber++;
        }

        timer += Time.deltaTime;
    }

    public void EnableWater()
    {
        shouldEnable = true;
        timer = 0f;
    }
}

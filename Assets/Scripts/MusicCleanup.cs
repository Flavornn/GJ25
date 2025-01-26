using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicCleanup : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if (MusicManager.instance != null)
        {
            Destroy(MusicManager.instance.gameObject);
        }
    }

    
}

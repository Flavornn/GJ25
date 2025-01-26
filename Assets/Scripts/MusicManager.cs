using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static MusicManager instance {get; private set;}
    void Start()
    {
        DontDestroyOnLoad(this);
        instance = this;
        

    }
}

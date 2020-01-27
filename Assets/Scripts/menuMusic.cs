using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour
{
    private static menuMusic instance = null;
    public static menuMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        playMusic();
    }

    void Update()
    {
        playMusic();
    }

    void playMusic()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

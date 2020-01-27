using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMenuMusic : MonoBehaviour
{
    private bool playMenuMusic;

    // Start is called before the first frame update
    void Start()
    {
        playMenuMusic = true;

        if (playMenuMusic == false)
        {
            return;
        }
        menuMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    public void resumeMenuMusic()
    {
        playMenuMusic = false;//make menu music play - Will
        menuMusic.Instance.gameObject.GetComponent<AudioSource>().Play();
    }
}

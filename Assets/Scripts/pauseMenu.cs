using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public string mainMenuScene;
    public GameObject pauseScreen;
    public bool isPaused;

    private PlayerController PlayerController;
    private StopMenuMusic StopMenuMusic;

    // Start is called before the first frame update
    void Start()
    {
        //gives us access to the PlayerController script
        GameObject PlayerControllerObject = GameObject.FindWithTag ("Player"); //finds the DestroyObject script
        if (PlayerControllerObject != null)
        {
            PlayerController = PlayerControllerObject.GetComponent <PlayerController>();
        }

        if (PlayerController == null)
        {
            Debug.Log ("Cannot find 'PlayerController' script");
        }


        GameObject StopMenuMusicObject = GameObject.FindWithTag ("GameController"); //finds the DestroyObject script
        if (StopMenuMusicObject != null)
        {
            StopMenuMusic = StopMenuMusicObject.GetComponent <StopMenuMusic>();
        }

        if (PlayerController == null)
        {
            Debug.Log ("Cannot find 'StopMenuMusic' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resumeGame();
            }
            else
            {
                isPaused = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0f; //freezes the game
                AudioListener.pause = true;
                PlayerController.stopShot();
            }
        }
    }

    public void resumeGame()
    {
        isPaused = false; //game begins with this set to false
        pauseScreen.SetActive(false);
        Time.timeScale = 1f; //resumes play
        AudioListener.pause = false;
        PlayerController.resumeShot();
    }

    public void returnToMain()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        StopMenuMusic.resumeMenuMusic();
        SceneManager.LoadScene(mainMenuScene);
    }
}

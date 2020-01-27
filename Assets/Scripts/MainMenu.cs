using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;
    public string levelSelect;
    public string returnMenu;
    public string regMode;
    public string survivalMode;

    

    public void newGame()
    {
        //SceneManager.LoadScene(newGameScene);
        SceneManager.LoadScene(levelSelect);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(returnMenu);
    }

    public void normalGame()
    {
        SceneManager.LoadScene(regMode);
    }

    public void survivalGame()
    {
        SceneManager.LoadScene(survivalMode);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}

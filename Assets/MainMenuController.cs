using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You Quit the game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Level01");
    }

    public void FromAboutToMain()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }

    public void FromMainToAbout()
    {
        SceneManager.LoadScene("Scenes/About");
    }
}

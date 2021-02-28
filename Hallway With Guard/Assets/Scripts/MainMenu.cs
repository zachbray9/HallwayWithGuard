using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }



    public void playGame()
    {
        SceneManager.LoadScene(1);                                     //Add the correct scene to the function
    }

    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

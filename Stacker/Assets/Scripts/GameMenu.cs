using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameManager gameManager;

     public void Continue()
    {
        gameManager.ContinueGame();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}

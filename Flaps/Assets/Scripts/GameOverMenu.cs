using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    //game over 
  //  public static bool isPaused = false;

    [SerializeField] GameObject player;
    public GameObject gameMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -5)
        {
            GameOver(); 
        }
    }

    void GameOver()
    {
        gameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //isPaused = true;

    }

   public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

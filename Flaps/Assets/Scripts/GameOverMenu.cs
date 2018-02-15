using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    //game over 
    //  public static bool isPaused = false;
    public static bool isOver = false;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Hud;
    public GameObject gameMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -5)
        {
            isOver = true;
            GameOver(); 
        }
    }

    void GameOver()
    {
        Hud.SetActive(false);
        gameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //isPaused = true;

    }

   public void Restart()
    {
        Hud.SetActive(true);
        isOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        isOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

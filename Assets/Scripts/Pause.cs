using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{

    public GameObject pauseCanvas;

    public bool pauseActive;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        pauseActive = false;
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        pauseActive = true;
        Time.timeScale = 0f;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }   
}

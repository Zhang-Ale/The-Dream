using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuOptions : MonoBehaviour
{
    public bool gameIsPaused;
    CanvasGroup blackCanv;
    public GameObject Options;
    public GameObject PressESCToPause;
    public GameObject PressESCToResume;
    public GameObject Controls; 
    private void Start()
    {
        blackCanv = GameObject.Find("Black canvas").GetComponent<CanvasGroup>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Update()
    {
        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame(); 
        }
    }
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            PressESCToPause.SetActive(false);
            PressESCToResume.SetActive(true);     
            Options.SetActive(true);
            Controls.SetActive(true); 
            blackCanv.alpha = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = true;
            PressESCToPause.SetActive(true);
            PressESCToResume.SetActive(false);
            Controls.SetActive(false);
            Options.SetActive(false);
            blackCanv.alpha = 0f;
        }
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ReturnStartMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}

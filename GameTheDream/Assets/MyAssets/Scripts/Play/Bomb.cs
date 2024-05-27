using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Bomb : MonoBehaviour
{
    public GameObject ExpCanvas;
    public AudioSource backgroundMusic;
    public AudioSource recording;

    bool gameStart; 
    bool isTicking = false;
    public Image whiteFade;

    //timeRemaining = 10:05 = 605
    private float timeRemaining = 601;
    bool timeIsRunning;
    public TextMeshProUGUI timeText;

    private bool cursorActivated = false;

    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(0f);

        SceneLoadManager.instance.ActivateNormalCursor();
    }

    void Update()
    {
        if (!gameStart && Input.GetKey(KeyCode.E))
        {
            ExpCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            gameStart = true;
        }

        if (gameStart)
        {
            if (!cursorActivated)
            {
                SceneLoadManager.instance.ActivateNormalCursor();
                cursorActivated = true;
            }

            StartCoroutine(PlayBackgroundMusic(1.5f));
            StartCoroutine(DisplayTime(timeRemaining));
            ActivateBomb();
            TimerTicking();
        }
    }

    IEnumerator DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        //62 % 60 = 1min2sec; 125 & 60 = 2min5sec; 46 % 60 = 46sec
        //float milliSeconds = (timeToDisplay % 1) * 1000;

        yield return new WaitForSeconds(0.1f);
        timeIsRunning = true;
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ActivateBomb()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                isTicking = true;
                timeIsRunning = false;
            }
        }
        //When the music ends, the dream ends as well, the protagonist wakes up, game over
        //Set a countdown timer with the music track. When the timeRemaining arrives a certain number
        //isTicking becomes true.
        //When music is about to end, the bomb activates: isTicking = true;
    }

    void TimerTicking()
    {
        if (isTicking == true)
        {
            StartCoroutine(BombCheck());
            //timeRemaining--;
            //Debug.Log(timeRemaining);
        }

        if (timeRemaining < 0)
        {
            isTicking = false;
        }
    }

    IEnumerator BombCheck()
    {
        yield return new WaitUntil(IsExplosion);
        whiteFade.CrossFadeAlpha(2, 5, false);
        yield return new WaitForSeconds(4f);
        backgroundMusic.Stop();
        yield return new WaitForSeconds(2f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 2);
    }

    bool IsExplosion()
    {
        if (timeRemaining > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator PlayBackgroundMusic(float waitTime)
    {
        backgroundMusic.volume = 0.1f;
        yield return new WaitForSeconds(waitTime);
        backgroundMusic.Play();
        recording.Play();
        yield return new WaitForSeconds(31f);
        recording.Stop();
        backgroundMusic.volume = 0.2f;
    }
}

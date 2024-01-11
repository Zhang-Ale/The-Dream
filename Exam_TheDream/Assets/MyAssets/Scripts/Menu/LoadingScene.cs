using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    /*To load the next scene:
     SceneManager.LoadScene("SceneName");
     or
     SceneManger.LoadScene(1);
     or
     SceneManager.LoadSceneAsync(sceneToLoad); 
     This one allows the current scene running until the new scene is ready
     Use AsyncOperation.isDone to check when the loading has finished 

    public void LoadNextScene()
    {
        //load the scene that's next on the list
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

        Make a reference to the AsyncOperation when you call it
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("Level1");
        
        Check if loading is finished
        if (loadingOperation.isDone)
        {
            SceneManager.LoadScene("Level1");
        }

        Return the progress of the load as float value between 0 and 1
        float loadProgress = loadingOperation.progress;
    */
    public GameObject loadingScreen;
    public string sceneToLoad;
    AsyncOperation loadingOperation;
    public Slider progressBar;
    public TextMeshProUGUI percentageLoaded;
    public CanvasGroup canvasGroup;
    public void Awake()
    {
        //DontDestroyOnLoad(gameObject);   
    }
    public void Start()
    {
        StartCoroutine(LoadingWait());        
    }
    IEnumerator LoadingWait()
    {
        yield return new WaitForSeconds(3f);
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        StartGame();
    }

    public void StartGame()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        percentageLoaded.text = Mathf.Round(progressValue + 1 * 100) + " %";
        
        if (loadingOperation.isDone)
        {
            loadingScreen.SetActive(false);
            //StartCoroutine(StartLoad());
        }
    }

    IEnumerator StartLoad()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
        {
            yield return null;
        }
        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        loadingScreen.SetActive(false);
    }

    //fade the loading screen from CanvasGroup component
    IEnumerator FadeLoadingScreen(float targetValue, float fadeDuration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }

    /* 
    || is used for 'or', && is used for 'and'
    a++ means a=a+1, a-- means a=a-1
    a+=b means a=a+b, a-=b means a=a-b, a*=b means a=a*b, a/=b means a=a/b
    so a+=1 means a=a+1
    var*operator*=expression means var=var*operator*expression

    yield tells unity to stop what's doing and continue again on the next frame
    yield return null means: will wait until next frame and then continue execution. 
    if while loop, without yield return null, the execution executes through the while loop in one frame. 
    while loop executes if the condiiton in the parenthesis is true, and will only exit when the condition 
    becomes false. It's a loop inside the function and unes until the condition is fake.
    'If' is an update and the function executes once per frame, but with 'while' it executes in one frame.
    */
}

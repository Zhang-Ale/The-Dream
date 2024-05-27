using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager instance;
    public TextMeshProUGUI ValueTxt;

    public Texture2D myNormalCursor, myFPSCursor, myOpenCursor, myCloseCursor;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //ValueTxt.text = PersistentManager.Instance.Value.ToString();
    }

    public void ActivateNormalCursor()
    {
        Debug.Log("Activating normal cursor");
        #if UNITY_WEBGL
        Cursor.SetCursor(myNormalCursor, Vector2.zero, CursorMode.ForceSoftware);
        #else
        Cursor.SetCursor(myNormalCursor, Vector2.zero, CursorMode.Auto);
        #endif
    }

    public void ActivateOpenCursor()
    {
        #if UNITY_WEBGL
        Cursor.SetCursor(myOpenCursor, Vector2.zero, CursorMode.ForceSoftware);
        #else
        Cursor.SetCursor(myOpenCursor, Vector2.zero, CursorMode.Auto);
        #endif
    }

    public void ActivateCloseCursor()
    {
        #if UNITY_WEBGL
        Cursor.SetCursor(myCloseCursor, Vector2.zero, CursorMode.ForceSoftware);
        #else
        Cursor.SetCursor(myCloseCursor, Vector2.zero, CursorMode.Auto);
        #endif
    }

    public void ActivateFPSCursor()
    {
        #if UNITY_WEBGL
        Cursor.SetCursor(myFPSCursor, Vector2.zero, CursorMode.ForceSoftware);
        #else
        Cursor.SetCursor(myFPSCursor, Vector2.zero, CursorMode.Auto);
        #endif
    }

    public void ClearCursor()
    {
        #if UNITY_WEBGL
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        #else
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        #endif
    }

    public void GoToFirstScene()
    {
        SceneManager.LoadScene("Level1");
        PersistentManager.Instance.Value++;
    }

    public void GoToSecondScene()
    {
        SceneManager.LoadScene("Level2");
        PersistentManager.Instance.Value++;
    }
}

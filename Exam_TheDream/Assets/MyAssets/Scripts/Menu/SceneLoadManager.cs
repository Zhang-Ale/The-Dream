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
        Cursor.SetCursor(myNormalCursor, Vector2.zero, CursorMode.Auto);
    }
    public void ActivateOpenCursor()
    {
        Cursor.SetCursor(myOpenCursor, new Vector2(myFPSCursor.width / 2, myFPSCursor.height / 2), CursorMode.Auto);
    }
    public void ActivateCloseCursor()
    {
        Cursor.SetCursor(myCloseCursor, new Vector2(myFPSCursor.width / 2, myFPSCursor.height / 2), CursorMode.Auto);
    }
    public void ActivateFPSCursor()
    {
        Cursor.SetCursor(myFPSCursor, new Vector2 (myFPSCursor.width/2, myFPSCursor.height/2), CursorMode.Auto);
    }
    public void ClearCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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

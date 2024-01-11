using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCursor : MonoBehaviour
{
    public Texture2D myNormalCursor;

    void Start()
    {
        Cursor.SetCursor(myNormalCursor, Vector2.zero, CursorMode.Auto);
    }

}

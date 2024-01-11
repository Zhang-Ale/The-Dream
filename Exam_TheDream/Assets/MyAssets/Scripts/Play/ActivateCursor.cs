﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCursor : MonoBehaviour
{
    private bool canGrab;
    public PauseMenuOptions _pauseMenuOptions;

    private void Update()
    {
        _pauseMenuOptions = GameObject.Find("Setting canvas").GetComponent<PauseMenuOptions>();
        if (!_pauseMenuOptions.gameIsPaused)
        {
            ChangeMouse();
        }
    }

    void ChangeMouse()
    {
        if (canGrab)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneLoadManager.instance.ActivateCloseCursor();
            }
            if (Input.GetMouseButtonUp(0))
            {
                SceneLoadManager.instance.ActivateOpenCursor();
            }
        }
    }

    private void OnMouseEnter()
    {
        SceneLoadManager.instance.ActivateOpenCursor();
        canGrab = true;
    }
    private void OnMouseExit()
    {
        SceneLoadManager.instance.ActivateNormalCursor();
        canGrab = false;
        //SceneLoadManager.instance.ClearCursor();
    }
}

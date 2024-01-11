using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputScript : MonoBehaviour
{
    //(uso questo se non avessi il: public static InputManager Singleton; nel script InputManger.cs)
    //public InputManager TargetInputManager; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Nella parentesi di GeKeyDown() scrivo il nome dell'Input nel Prj setting
        if (Input.GetButtonDown("Jump") || (Input.GetKeyDown(KeyCode.Space)))
        {
            //(uso questo se non avessi il: public static InputManager Singleton; )
            //print(TargetInputManager.TestFloat); 
            //print(InputManager.Singleton.TestFloat);

            //print("Hello World");
        }

    }
}

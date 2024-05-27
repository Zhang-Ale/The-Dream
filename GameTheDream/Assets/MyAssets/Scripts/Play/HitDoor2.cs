using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDoor2 : MonoBehaviour
{
    public bool Pass2;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "PressOnePlates1" || other.name == "PressOnePlates2")
        {
            Debug.Log("Yes");
            Pass2 = true;
        }
    }
}

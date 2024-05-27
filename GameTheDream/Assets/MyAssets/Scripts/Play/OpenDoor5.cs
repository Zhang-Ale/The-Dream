using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor5 : MonoBehaviour
{ 
    public GameObject door5;
    private float _velocity = 20f;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "RszObj(Clone)")
        {
            MoveDoor();   
        }
    }
    private bool MoveDoor() 
    {
        if (door5.transform.position.y > -100f)
        {
            door5.transform.Translate(Vector3.down * _velocity * Time.deltaTime);
            return true;
        }
        else 
            return false; 
    }
}

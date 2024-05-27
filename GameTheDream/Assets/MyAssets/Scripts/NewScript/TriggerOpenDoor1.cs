using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor1 : MonoBehaviour
{

    public AudioSource HitSound;
    public AudioSource LeaveSound;
    public GameObject Door;
    public bool isTriggered = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            if(isTriggered == false)
            {
                HitSound.Play();
                isTriggered = true;
                Door.GetComponent<Door02>().Check();
            }
     
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            LeaveSound.Play();
            isTriggered = false;
            Door.GetComponent<Door02>().Check();
        }
    }

}



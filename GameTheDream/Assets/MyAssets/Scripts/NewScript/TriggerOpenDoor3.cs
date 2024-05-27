using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor3 : MonoBehaviour
{

    public AudioSource HitSound;
    public AudioSource LeaveSound;
    public bool isTriggered = false;
    public GameObject Door;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable" && other.name == "right")
        {
            if (isTriggered == false)
            {
                HitSound.Play();
                Door.SetActive(false);
                isTriggered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable" && other.name == "right")
        {
            LeaveSound.Play();
            isTriggered = false;
        }
    }

}



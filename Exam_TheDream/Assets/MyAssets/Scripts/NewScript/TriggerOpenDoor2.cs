using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor2 : MonoBehaviour
{

    public AudioSource HitSound;
    public AudioSource LeaveSound;
    public bool isTriggered = false;
    public GameObject Render;
    public PortalTeleport PT;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            if(isTriggered == false)
            {
                HitSound.Play();
                isTriggered = true;
                Render.SetActive(true);
                PT.isOverlapping = true;
            }
     
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            LeaveSound.Play();
            isTriggered = false;
            Render.SetActive(false);
            PT.isOverlapping = false;
        }
    }

}



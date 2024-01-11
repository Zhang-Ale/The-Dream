using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSound : MonoBehaviour
{
    public AudioSource HitSound;
    public AudioSource LeaveSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            HitSound.Play();
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            LeaveSound.Play();
        } 
    }
}

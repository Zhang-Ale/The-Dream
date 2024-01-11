using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor : MonoBehaviour
{

    public AudioSource HitSound;
    public AudioSource LeaveSound;
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            HitSound.Play();
            Door.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            LeaveSound.Play();
            Debug.Log("Out");
        }
    }
}



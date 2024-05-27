using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
    public bool isTrigger = false;
    public GameObject _door;
    DoorMove moveDoor;

    void Start()
    {
        moveDoor = _door.GetComponent<DoorMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grabbable")
        {
            isTrigger = true;
            moveDoor._canMoveDoor = true;
        }
    }
}

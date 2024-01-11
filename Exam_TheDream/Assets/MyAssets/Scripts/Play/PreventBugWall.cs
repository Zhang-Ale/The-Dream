using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventBugWall : MonoBehaviour
{
    public GameObject _grab;
    public Transform _place;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grabbable")
        {
            Debug.Log("ss");
            _grab.transform.position = _place.position;
        }
    }
}

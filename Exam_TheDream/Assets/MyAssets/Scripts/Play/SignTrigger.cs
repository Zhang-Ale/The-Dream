using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrigger : MonoBehaviour
{
    public GameObject wall;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Table1")
        {
            Destroy(wall);
        }
    }
}

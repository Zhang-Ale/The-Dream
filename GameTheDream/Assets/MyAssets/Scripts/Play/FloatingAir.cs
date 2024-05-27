using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAir : MonoBehaviour
{
    public GameObject FPC;
    Rigidbody rb;

    public void Awake()
    {
        FPC = GameObject.FindGameObjectWithTag("Player");
        //rb = FPC.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPC")
        {
            //rb.AddForce(new Vector3(0, 20f, 0), ForceMode.Impulse);
        }
    }

}

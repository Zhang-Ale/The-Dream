using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisableWall : MonoBehaviour
{
    private MeshCollider Collider;
    private void Start()
    {
        Collider = GetComponent<MeshCollider>();
        Collider.enabled = false;
        StartCoroutine(Touchable(8f));

        //this one means to toggle between enabled and disabled
        //Colider.enabled = !Collider.enabled
    }

    /*private void FixedUpdate()
    {
        DateTime today = DateTime.Now;
        Debug.Log(today + " seconds");
    }*/

    IEnumerator Touchable(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Collider.enabled = true;
        }
 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPillar : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       if (other.name == "ResizableObject3")
        {
            Transform Ts = other.GetComponent<Transform>();
            
        }
    }
}

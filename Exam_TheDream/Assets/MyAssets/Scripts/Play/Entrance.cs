using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public Material myMaterial;
    
    void Start()
    {
        myMaterial.color = Color.yellow;
    }

    private void OnTriggerEnter(Collider other)
    {
        //The door color changes
    }
}

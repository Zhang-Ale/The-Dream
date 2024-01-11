using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGuide : MonoBehaviour
{
    public Image Guide;
    public Image _guideModel;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPC")
        {

            if (Input.GetKey(KeyCode.E))
            {                
                Guide.enabled = true;
                _guideModel.enabled = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    public GameObject Gun;
    public GameObject _gunModel;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPC")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Gun.SetActive(true);
                _gunModel.SetActive(false);
            }
        }   
    }
}

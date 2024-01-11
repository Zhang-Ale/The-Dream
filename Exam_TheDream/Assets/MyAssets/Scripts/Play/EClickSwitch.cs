using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EClickSwitch : MonoBehaviour
{
    public TextMeshProUGUI Guidance;
    public GameObject door1;
    public bool canOpen = false;
    private void Start()
    {
 //       Guidance.gameObject.SetActive(false);
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.name == "Cover")
        {
            Vector3 prvPos = door1.transform.position;
            yield return new WaitForSeconds(5f);
            Vector3 actPos = door1.transform.position;

            if (prvPos == actPos)
            {
                Guidance.gameObject.SetActive(true);
            }  
        }

        if (other.name == "FPC")
        {
            canOpen = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public PortalTeleport PT;
    public GameObject Render;

    void Start()
    {

        Render.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "ColDetect1")
        {

            if (SizeOkay())
            {
                StartCoroutine(CountTime(3f));
            } 
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if(other.name == "ColDetect")
        {
           Render.SetActive(false);
           PT.isOverlapping = false;

            gameObject.layer = 8;
        }
        
    }*/

    IEnumerator CountTime(float _time)
    {
            yield return new WaitForSeconds(_time);
            Render.SetActive(true);
            PT.isOverlapping = true;

            gameObject.layer = 0;
            yield return null;

    }

    public bool SizeOkay()
    {
        Vector3 local = transform.localScale;
        float MinX = 0.7f;
        float MaxX = 1.3f;

        if (local.x >= MinX && local.x <= MaxX)
        {

            return true;
        }
        else
            return false;

    }
    
}


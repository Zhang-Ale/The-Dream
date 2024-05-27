using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TracingPlates : MonoBehaviour
{
    public int plateID;
    public bool isMatched;
    public PlateControl Validator;    
    public float _lightValue;

    private void Start()
    {
        _lightValue = transform.GetChild(1).GetComponent<Light>().intensity;      
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.tag == "Grabbable")
        {
            if (other.GetComponent<RszID>().ObjID == plateID)
            {               
                //StartCoroutine(ActivateLight(0, 15, 2));
                isMatched = true;
                Validator.AddMatch();               
            }           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            if (other.GetComponent<RszID>().ObjID == plateID)
            {
                //StartCoroutine(DisactivateLight());
                isMatched = false;
                Validator.MinusMatch();
            }
        }
    }

    IEnumerator ActivateLight(float v_start, float v_end, float duration)
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Starting");

        _lightValue = Mathf.Lerp(v_start, v_end, duration);
        Debug.Log("Here");

        /*float elapsed = 0.0f;
        while (elapsed < duration)
        {
            _lightValue = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _lightValue = v_end;*/

        /*float delta = 10 - 0;
        delta *= Time.deltaTime;
        _lightValue += delta;*/

        //_lightValue = Mathf.MoveTowards(0, 10, 2 * Time.deltaTime);

    }

    IEnumerator DisactivateLight()
    {
        yield return new WaitForSeconds(1.5f);
        _lightValue = Mathf.MoveTowards(10, 0, 2 * Time.deltaTime);
        yield return null;
    }

}

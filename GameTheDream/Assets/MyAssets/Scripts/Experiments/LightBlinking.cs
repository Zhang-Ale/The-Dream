using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    Light _light;
    void Start()
    {
        _light = GameObject.Find("Point Light").GetComponent<Light>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            _light.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            _light.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }
}

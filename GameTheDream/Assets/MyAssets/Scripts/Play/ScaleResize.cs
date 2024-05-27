using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleResize : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector4(Mathf.PingPong(Time.time, 7) + 1, transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
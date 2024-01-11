using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public Transform target;
    private float t = 0.01f;
    [SerializeField]
    public bool _canMoveDoor;

    public void Start()
    {
        _canMoveDoor = false;
    }

    public void FixedUpdate()
    {
        StartCoroutine(Set());      
    }

    public IEnumerator Set()
    {
        if (_canMoveDoor)
        {
            Coroutine b = StartCoroutine(Move());
            yield return new WaitForSeconds(1.1f);
            _canMoveDoor = false;
            StopCoroutine(b);
            yield return null;
        }       
    }

    public IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);

        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.Lerp(a, b, t);

        yield return null;
    }
}

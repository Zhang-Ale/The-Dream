using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRszObj : MonoBehaviour
{
    public GameObject RszObj;
    public GameObject Spawn;
    public int _RszID;
    private GameObject xxx;
    public bool isCreated = false;
    private void Start()
    {
        isCreated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet(Clone)")
        {
            isHit();
        }
    }

    private void isHit()
    {
        if (!isCreated)
        {
            xxx = Instantiate(RszObj, Spawn.transform.position, Quaternion.identity);
            xxx.GetComponent<RszID>().ObjID = _RszID;
            isCreated = true;
        }
    }

}

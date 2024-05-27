using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirst : MonoBehaviour
{
    public GameObject RszObj;
    public GameObject Spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet(Clone)")
        {
            isHit();
            Destroy(this);
        }

    }

    private bool isHit()
    {
        Instantiate(RszObj, Spawn.transform.position, Quaternion.identity);


        return true;
    }
}

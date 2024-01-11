using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFirstDoor : MonoBehaviour
{
    public GameObject door1;
    public GameObject player;
    private float _vel = 150f;
    public GameObject Trigger;
    private EClickSwitch script;

    private void Start()
    {
        script = Trigger.GetComponent<EClickSwitch>();
    }
    void Update()
    {
        if (script.canOpen == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                MoveD();
            }         
        }
    }
    private bool MoveD()
    {
        if (door1.transform.position.y > -100f)
        {
            door1.transform.Translate(Vector3.down * _vel * Time.deltaTime);
            return true;
        }
        else
            return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public DoorMove _doorMove;
    public Rigidbody myRb;
    public GameObject door0;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    public GameObject door6;
    public Transform door6Target;

    public HitDoor2 HD;
    public bool Pass1 = false;
    public bool pass2 = false;

    //private float _velocity = 20f;
    private Animator animator;
    private Animator animator1;
    private bool door0OpenTrigger = false;
    private bool door0CloseTrigger = false;

    void Start()
    {
        if (myRb == null)
        {
            myRb = GetComponent<Rigidbody>();
        }

        _doorMove = GameObject.Find("Door0").GetComponent<DoorMove>();
    }
    void Update()
    {
        if(HD.Pass2)
        {
            pass2 = true;
        }

        if (Pass1 && pass2)
        {
            animator1 = door2.GetComponent<Animator>();
            animator1.SetBool("Door1OpenTrigger", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.name == "Torus")
        {
            door3.transform.Translate(Vector3.up * _velocity * Time.deltaTime);
        }*/

        if (other.name == "PressOnePlates" && !door0OpenTrigger)
        {
            //door1.transform.Translate(new Vector3(63, 4, -2) * Time.deltaTime);
            //door1.transform.position = Vector3.MoveTowards(door1.transform.position, new Vector3(63, 4, -2), Time.deltaTime * _velocity);
            //door1.GetComponent<Animation>().Play("DoorOpen");

            /*animator = door0.GetComponent<Animator>();
            animator.SetBool("Door0IsClosed", false);
            animator.SetBool("Door0OpenTrigger", true);
            door0OpenTrigger = true;
            animator.SetBool("Door0IsOpen", true);
            animator.SetBool("Door0CloseTrigger", false);
            door0CloseTrigger = false;*/
            _doorMove._canMoveDoor = true;
        }

        if (other.name == "PressOnePlates1" || other.name == "PressOnePlates2")
        {

            Pass1 = true;
        }

        if (other.name == "PressOnePlates4")
        {
            Vector3 a = transform.position;
            Vector3 b = door6Target.position;
            door6.transform.position = Vector3.Lerp(a, b, 2f); ;
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PressOnePlates" && !door0CloseTrigger)
        {
            /*animator = door0.GetComponent<Animator>();
            animator.SetBool("Door0IsOpen", false);
            animator.SetBool("Door0CloseTrigger", true);
            door0CloseTrigger = true;
            animator.SetBool("Door0IsClosed", true);
            animator.SetBool("Door0OpenTrigger", false);
            door0OpenTrigger = false;*/
        }
    }

}

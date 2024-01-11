using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 7f;
    public float gravity = -18.5f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask, grabbableMask;
    bool isOnGround;
    bool isOnGrabbable;
    public AudioSource PassLevel;
    bool _Play = false;
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isOnGrabbable = Physics.CheckSphere(groundCheck.position, groundDistance, grabbableMask);
        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isOnGrabbable && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetButtonDown("Jump") && isOnGrabbable)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Air")
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -6f * gravity);
        }
        if (other.tag == "PassLevel" && _Play == false)
        {
            PassLevel.Play();

            _Play = true;
        }
    }
}

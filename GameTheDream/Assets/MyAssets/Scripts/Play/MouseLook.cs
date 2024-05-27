using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public Transform FPC, Gun;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 75f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        /*Vector3 rotGun = Gun.transform.rotation.eulerAngles;
        Vector3 rotFPC = FPC.transform.rotation.eulerAngles;
        rotGun.x -= mouseY;
        rotGun.z = 0;
        rotFPC.y += mouseX;
        Gun.rotation = Quaternion.Euler(rotGun);
        FPC.rotation = Quaternion.Euler(rotFPC);*/
    }
}

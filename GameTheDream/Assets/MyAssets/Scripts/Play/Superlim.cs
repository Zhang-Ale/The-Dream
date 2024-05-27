using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superlim : MonoBehaviour
{
    [Header("Components")]
    public Transform target; //the target object to be scaled

    [Header("Parameters")]
    public LayerMask targetMask; //the layer mask used to hit only potential targets with a raycast
    public LayerMask ignoreTargetMask; //the layer mask used to ignore the player and target objects while raycasting
    public float offsetFactor; //the offset amount for positioning the object so it doesn't clip into walls

    float originalDistance; //the original distance between the player camera and the target
    float originalScale; //the original scale of the target objects prior to being resized
    Vector3 targetScale; //the scale we want out object to be set to each frame

    public bool Grabbed;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleInput();
        ResizeTarget();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (target == null) //if we currently do not have a target
            { //fire a raycast with the layer mask that only hits potential targets
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetMask))
                {
                    //set out target variable to be the transform object we hit with our raycast
                    target = hit.transform;
                    // Disable physics for the object
                    target.GetComponent<Rigidbody>().isKinematic = true;
                    // Calculate the distance between the camera and the object
                    originalDistance = Vector3.Distance(transform.position, target.position);
                    // Save the original scale of the object into our originalScale Vector3 variabble
                    originalScale = target.localScale.x;
                    // Set our target scale to be the same as the original for the time being
                    targetScale = target.localScale;
                    Grabbed = true;
                }
            }
            else //if we do have a target
            {
                // Reactivate physics for the target object
                target.GetComponent<Rigidbody>().isKinematic = false;
                // Set our target variable to null
                target = null;
                Grabbed = false;
            }
        }
    }

    void ResizeTarget()
    {
        if (target == null)
        {
            // Return from this method, nothing to do here
            return;
        }

        // Cast a ray forward from the camera position, ignore the layer that is used to acquire targets
        // so we don't hit the attached target with our ray
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ignoreTargetMask))
        {
            // Set the new position of the target by getting the hit point and moving it back a bit
            // depending on the scale and offset factor
            target.position = hit.point - transform.forward * offsetFactor * targetScale.x;

            // Calculate the current distance between the camera and the target object
            float currentDistance = Vector3.Distance(transform.position, target.position);
            // Calculate the ratio between the current distance and the original distance
            float s = currentDistance / originalDistance;
            // Set the scale Vector3 variable to be the ratio of the distances
            targetScale.x = targetScale.y = targetScale.z = s;

            // Set the scale for the target objectm, multiplied by the original scale
            target.transform.localScale = targetScale * originalScale;
        }
    }
}

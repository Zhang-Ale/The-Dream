using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour
{
    public float MagnaticForceMultiplier = 10;
    Vector3 CurrentHand3DSpeed;
    Grabbable distanceGrabbableObject;
    private Collider myCollider;
    List<Grabbable> grabbableInHand = new List<Grabbable>();
    //public bool haveGrabbed;

    //Set the X of the thing below to 10.9
    public Vector3 ObjectVelocityToSet;
    // Start is called before the first frame update
    void Start()
    {
        SetUpTrigger();
        InputManager.Singleton.GrabEvent.AddListener(GrabObjectInHand);
        InputManager.Singleton.ThrowEvent.AddListener(ThrowObjectInHand);
        //haveGrabbed = InputManager.Singleton.GrabBool;
        StartCoroutine(GrabBehaviorRotationSpeedEnumerator());
        StartCoroutine(GrabBehaviorSpeedEnumerator());
    }

    void FixedUpdate()
    {
        UpdateObjectVelocity();
        //Set this active when the player reaches the entrance trigger of a certain level
        GrabAtDistance();
        Raycast();
    }

    void SetUpTrigger()
    {
        myCollider = GetComponent<SphereCollider>();
        if (myCollider == null)
        {
            myCollider = gameObject.AddComponent<SphereCollider>();
        }

        myCollider.isTrigger = true;
    }

    void GrabAtDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Grabbable tempGrabbable = hit.collider.gameObject.GetComponent<Grabbable>();
            
            if (tempGrabbable != null)
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
                distanceGrabbableObject = tempGrabbable;
            }
            else
            {
                distanceGrabbableObject = null;
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            }
        }
        //se il raycast non prende niente, questo distanceGrabbableObject diventa vuoto
        else
        {
            distanceGrabbableObject = null;
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.white);
        }
    }

    void UpdateObjectVelocity()
    {
        if (CheckIfMovementTowardsMe())
        {
            ObjectVelocityToSet = CurrentHand3DSpeed * 10;
        }
        else
        {
            ObjectVelocityToSet = Vector3.zero;
        }
    }

    IEnumerator GrabBehaviorSpeedEnumerator()
    {
        Vector3 oldPosition = transform.position;
        while (true)
        {
            CurrentHand3DSpeed = (transform.position - oldPosition) * 60;
            oldPosition = transform.position;

            //avviene 60 volte al secondo
            yield return new WaitForSecondsRealtime(1f / 60f);
        }
    }

    IEnumerator GrabBehaviorRotationSpeedEnumerator()
    {
        Vector3 oldRotation = transform.eulerAngles;
        while (true)
        {
            CurrentHand3DSpeed = (transform.eulerAngles - oldRotation) * 60f;
            oldRotation = transform.eulerAngles;
            yield return new WaitForSecondsRealtime(1f / 60f);
        }
    }

    float oldDistance;
    bool CheckIfMovementTowardsMe()
    {
        if (Vector3.Distance(transform.position, myCollider.transform.position) >= oldDistance)
        {
            oldDistance = Vector3.Distance(transform.position, myCollider.transform.position);
            return false;
        }
        else
        {
            oldDistance = Vector3.Distance(transform.position, myCollider.transform.position);
            return true;
        }
    }

    void Raycast()
    {
        if (distanceGrabbableObject != null && !grabbableInHand.Contains(distanceGrabbableObject))
        {
            distanceGrabbableObject.GetComponent<Renderer>().material.color = Color.blue;
            //distanceGrabbableObject.myRb.AddForce(grabBehavior3DSpeed * MagnaticForceMultiplier);
            if (Input.GetMouseButton(0))
            {
                distanceGrabbableObject.myRb.isKinematic = true;
                distanceGrabbableObject.transform.parent = transform; //così l'oggetto è parentato alla mia mano
                grabbableInHand.Add(distanceGrabbableObject);
            }
        }

        else if (distanceGrabbableObject != null && grabbableInHand.Contains(distanceGrabbableObject))
        {
            distanceGrabbableObject.GetComponent<Renderer>().material.color = Color.red;
            distanceGrabbableObject.myRb.isKinematic = false;
            distanceGrabbableObject.transform.parent = null; //in questo oggetto oggetto è parentato alla mia mano
            grabbableInHand.Remove(distanceGrabbableObject);
        }
    }

    #region DirectGrab
    void GrabObjectInHand()
    {
        
        for (int i = 0; i < grabbableInHand.Count; i++)
        {
            grabbableInHand[i].myRb.isKinematic = true;
            grabbableInHand[i].transform.parent = transform;
        }
    }

    void ThrowObjectInHand()
    {  
        if (Input.GetMouseButtonDown(2))
            {
                for (int i = 0; i < grabbableInHand.Count; i++)
                {
                   grabbableInHand[i].transform.parent = null;
                   grabbableInHand[i].myRb.isKinematic = false;
                   grabbableInHand[i].myRb.AddForce(transform.forward * 100f);
                }
            }
    }

    void OnTriggerEnter(Collider collidedObject)
    {
        Grabbable tempGrabbable = collidedObject.gameObject.GetComponent<Grabbable>();
        if (tempGrabbable != null && !grabbableInHand.Contains(tempGrabbable))//se la lista non contiene tempGrabbable
        {
            tempGrabbable.myRb.isKinematic = true;
            tempGrabbable.transform.parent = transform; //in questo oggetto oggetto è parentato alla mia mano
            grabbableInHand.Add(tempGrabbable);
            //haveGrabbed = true;
        }
    }
    /*void OnTriggerExit(Collider collidedObject)
    {
        Grabbable tempGrabbable = collidedObject.gameObject.GetComponent<Grabbable>();
        if (tempGrabbable != null && grabbableInHand.Contains(tempGrabbable))//se la lista non contiene tempGrabbable
        {
            tempGrabbable.myRb.isKinematic = false;
            tempGrabbable.transform.parent = null;
            grabbableInHand.Remove(tempGrabbable);
            //haveGrabbed = false;
        }
    }*/
    #endregion DirectGrab
}

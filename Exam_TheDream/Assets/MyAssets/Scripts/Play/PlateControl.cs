using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour
{
    public TracingPlates[] TracingPlates;
    public int matchNumber = 0;
    public GameObject door;

    public void AddMatch()
    {
        matchNumber += 1;
        //Debug.Log("Plus 1");
        ValidatePressedOrder();
    }
    public void MinusMatch()
    {
        matchNumber -= 1;
        //Debug.Log("Minus 1");
        ValidatePressedOrder();
    }

    public void ValidatePressedOrder()
    {

        if (TracingPlates.Length == matchNumber)
        {
            //Debug.Log("Door open.");
            door.SetActive(false);
        }
        else
        {
            //Debug.Log("Not complete.");
        }

    }
}
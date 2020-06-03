using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenva.VR;

public class VrTelePointer : MonoBehaviour
{
    [Tooltip("Maximum Interaction Distance")]
    public float maxDistance = 10;

    [Tooltip("Shwo ray for debugging")]
    public bool showRay = false;

    //Keep track of interactables
    public Interactable currInteractable;
    public Interactable prevInteractable;

    public Vector3 EndPosition { get; private set; }

    public bool stillOnFloor = false;
    // Update is called once per frame
    void Update()
    {
        RayCast();
    }

    void RayCast()
    {
        RaycastHit target;
        //found an object
        if (Physics.Raycast(transform.position, transform.forward, out target, maxDistance))
        {

            EndPosition = target.point;
            currInteractable = target.transform.GetComponent<Interactable>();

            if (target.transform.tag == "ground")
                stillOnFloor = true;
            else
                stillOnFloor = false;

            //call selection method
            if (currInteractable)
            {
                currInteractable.Over();
            }

        }

        //no object found
        else
        {
            EndPosition = transform.position + transform.forward * maxDistance;
            stillOnFloor = false;
            //call unselection method
            if (currInteractable)
            {
                currInteractable.Out();
            }
        }

        //check that selection chagned at all
        if (currInteractable != prevInteractable)
        {
            prevInteractable?.Out();
        }
        prevInteractable = currInteractable;

        if (showRay)
        {
            Debug.DrawRay(transform.position, EndPosition - transform.position, Color.blue);
        }
    }

    public void PressButton()
    {
        currInteractable?.ButtonDown();
    }

    public void ReleaseButton()
    {
        if (stillOnFloor)
            currInteractable?.ButtonUp();
    }
}

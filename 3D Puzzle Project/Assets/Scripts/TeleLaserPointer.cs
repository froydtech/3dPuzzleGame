using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR {
    [RequireComponent(typeof(LineRenderer))]

    public class TeleLaserPointer : MonoBehaviour
    {
        //[RequireComponent(typeof(LineRenderer))]
        

        [Tooltip("VRPointer Controller")]
        public VrTelePointer vrPointer;

        LineRenderer lineRend;

        Vector3[] linePoints;

        void Awake()
        {
            lineRend = GetComponent<LineRenderer>();
            linePoints = new Vector3[2];
            if (!vrPointer)
                throw new System.Exception("Vr Pointer Missing");
        }

        void Update()
        {
            //set the starting/ending position
            linePoints[1] = vrPointer.EndPosition;
            linePoints[0] = transform.position;

            lineRend.SetPositions(linePoints);


        }
    }
}

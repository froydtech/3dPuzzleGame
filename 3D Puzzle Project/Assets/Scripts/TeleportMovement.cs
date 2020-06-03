using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenva.VR;

public class TeleportMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportXRRig ()
    {                
        VrTelePointer endPos = GameObject.Find("RoboclawLeft").GetComponent<VrTelePointer>();
        transform.position = endPos.EndPosition;        
    }
}

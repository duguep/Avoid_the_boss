using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAction : MonoBehaviour
{
    private OVRGrabbable bla;
    private bool grabbed = false;

    private bool action = false;
    
    private void Start()
    {
        bla = GetComponent<OVRGrabbable>();
    }

    private void Update()
    {
        if (!bla.isGrabbed && grabbed == true)
            action = true;
        else
        {
            grabbed = bla.isGrabbed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (action)
        {
            
            print("boom" + other.gameObject.name);
            Destroy(this.gameObject);            
        }
        

    }
}


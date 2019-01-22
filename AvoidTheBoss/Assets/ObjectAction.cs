using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectAction : MonoBehaviour
{
    private OVRGrabbable bla;
    private bool grabbed = false;

    private bool action = false;

    public PhotonView view;
    
    private void Start()
    {
        if (view == null)
            view = GetComponent<PhotonView>();
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
            PhotonNetwork.Destroy(this.gameObject);            
        }
        

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ObjectAction : MonoBehaviour
{
    private OVRGrabbable bla;
    private bool grabbed = false;

    private bool action = false;

    private PhotonView view;
    
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
            if (view.Owner.UserId == PhotonNetwork.LocalPlayer.UserId)
                print("mine");
            else
            {
                print("request");
                view.RequestOwnership();
                print(view.Owner.UserId + " = " + PhotonNetwork.LocalPlayer.UserId);
            }
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


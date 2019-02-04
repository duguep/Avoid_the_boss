using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;

public class ObjectAction : MonoBehaviour
{
    private OVRGrabbable bla;
    private bool grabbed = false;

    private bool action = false;

    public PhotonView view;

    public Component powerup;

    public GameObject parent;
    
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
            IAction power = powerup as IAction;
            if (power != null) 
                power.Action();
            print("boom" + other.gameObject.name);
            PhotonNetwork.Destroy(parent ? parent : this.gameObject);
        }
        

    }
    
    public interface IAction
    {
        void Action();
    }
}


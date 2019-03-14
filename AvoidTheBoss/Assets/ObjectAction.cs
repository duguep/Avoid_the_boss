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
    private bool hasbeengrab = false;
    [SerializeField] private bool explosiv = false;

    public PhotonView view;

    public Component powerup;

    public GameObject parent;
    
    private void Start()
    {
        if (view == null)
            view = GetComponent<PhotonView>();
        bla = GetComponent<OVRGrabbable>();
        grabbed = false;
        action = false;
    }

    
    private void Update()
    {
        if (!bla.isGrabbed)
        {
            if (grabbed)
            {
                action = true;
            }
            else
            {
                action = false;
            }
        }
        else
        {
            if (explosiv)
                hasbeengrab = true;
            if (grabbed && !hasbeengrab)
            {
                GetComponent<AudioSource>().Play();
                hasbeengrab = true;
            }
            grabbed = bla.isGrabbed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (action)
        {
            IAction power = powerup as IAction;
            if (power != null) 
                power.Action(other);
            PhotonNetwork.Destroy(parent ? parent : this.gameObject);
        }
        

    }
    
    public interface IAction
    {
        int cost { get; set; }
        int pts { get; set; }
        int ptsToOther { get; set; }
        void Action(Collision other);
    }
}


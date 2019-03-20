using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Photon.Pun;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEditor;

public class ObjectAction : MonoBehaviour
{
    private OVRGrabbable bla;
    private bool grabbed = false;

    public bool action = false;
    private bool hasbeengrab = false;
    [SerializeField] private bool explosiv = false;

    public PhotonView view;

    public Component powerup;

    public GameObject parent;
    public int cost;
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
            if (grabbed && !hasbeengrab)
            {
                PhotonView photonView = GetComponent<PhotonView>();
                photonView.Owner.SetScore(photonView.Owner.GetScore() - cost);
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

    public class Fruit
    {
        public Fruit()
        {
            
        }

        public virtual void bla()
        {
            print("bka");
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


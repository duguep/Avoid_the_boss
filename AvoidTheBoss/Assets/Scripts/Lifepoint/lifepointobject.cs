using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

using Hashtable = ExitGames.Client.Photon.Hashtable;

public class lifepointobject : MonoBehaviour
{
	[SerializeField] private int maxPointLife;


	// Use this for initialization
	void Start ()
	{
		Hashtable photonView = GetComponent<PhotonView>().Owner.CustomProperties;
		
		if(photonView.ContainsKey(gameObject.name))
		{
			photonView[gameObject.name] = maxPointLife;
		}
		else
		{
			photonView.Add(gameObject.name, maxPointLife);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

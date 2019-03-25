using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Repair : MonoBehaviour, ObjectAction.IAction
{

	/// <summary>
	/// repair
	/// </summary>
	
	private PhotonView _photonView;
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }
	
	// Use this for initialization
	void Start () {
		_photonView = GetComponent<PhotonView>();
		cost = 200;
		pts = 0;
		ptsToOther = 0;
	}
	
	
	public void Action(Collision other)
	{
		print("Repair !!! ");

		Hashtable hashtable = _photonView.Owner.CustomProperties;

		ICollection keys = hashtable.Keys;

		foreach (String key in keys)
		{
			if (key != "invincible" && key != "canSeeByBoss")
			{
				hashtable[key] = -1;
			}
		}

	}
}

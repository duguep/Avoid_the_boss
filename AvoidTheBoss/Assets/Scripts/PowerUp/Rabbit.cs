﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class Rabbit : MonoBehaviour, ObjectAction.IAction
{
	/// <summary>
	/// Rabbit, met en place un lapin et qui rend invicible
	/// cost : 450
	/// le joueur owner : 0
	/// le joueur touché : 0
	/// </summary>
	
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }
	private PhotonView _photonView;

	private void Start()
	{
		_photonView = GetComponent<PhotonView>();
		cost = 450;
		pts = 0;
		ptsToOther = 0;

	}

	public void Action(Collision other)
	{
		print("Rabbit");			
		int player;
		if (int.TryParse(other.gameObject.tag, out player))
		{

			if (player < PhotonNetwork.PlayerList.Length && !PhotonNetwork.PlayerList[player].IsLocal)
			{
				_photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
				PhotonNetwork.PlayerList[player].SetScore(PhotonNetwork.PlayerList[player].GetScore() + ptsToOther);
			}			
		}
	}
}

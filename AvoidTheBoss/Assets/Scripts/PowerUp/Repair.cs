using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

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
		print("Reapir !!! ");

        
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

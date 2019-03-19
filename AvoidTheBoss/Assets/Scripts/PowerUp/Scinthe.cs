using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class Scinthe : MonoBehaviour, ObjectAction.IAction
{
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }
	private PhotonView _photonView;
	// Use this for initialization
	void Start () {
		_photonView = GetComponent<PhotonView>();
		cost = 500;
		pts = 0;
		ptsToOther = -50;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void Action(Collision other)
	{
		// point
		int player;
		if (int.TryParse(other.gameObject.tag, out player))
		{
			
			if (player < PhotonNetwork.PlayerList.Length && !PhotonNetwork.PlayerList[player].IsLocal)
			{
				_photonView.RPC("alarm", other.collider.GetComponent<PhotonView>().Owner);
				_photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
				PhotonNetwork.PlayerList[player].SetScore(PhotonNetwork.PlayerList[player].GetScore() + ptsToOther);
			}			
		}
	}
}

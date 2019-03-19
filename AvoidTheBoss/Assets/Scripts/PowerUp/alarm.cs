using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class alarm : MonoBehaviour, ObjectAction.IAction
{

	/// <summary>
	/// L'alarme enleve un indicateur pour le joueur
	/// cost = 300pts
	/// le joueur qui envoie gagne 0 pts
	/// le joueur toucher perd 50pts
	/// </summary>
	
	
	// Use this for initialization
	void Start ()
	{
		_photonView = GetComponent<PhotonView>();
		cost = 300;
		pts = 0;
		ptsToOther = -50;
	}
	
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }
	private PhotonView _photonView;
	
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

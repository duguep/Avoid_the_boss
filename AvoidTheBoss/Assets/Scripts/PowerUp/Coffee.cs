using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class Coffee : MonoBehaviour, ObjectAction.IAction
{
	/// <summary>
	/// Coffee, invincibilité
	/// cost = 600pts
	/// le joueur qui envoie gagne 0 pts
	/// le joueur toucher perd 0 pts
	/// </summary>
	
	// Use this for initialization
	void Start () {
		_photonView = GetComponent<PhotonView>();
		cost = 600;
		pts = 0;
		ptsToOther = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
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
				_photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
				PhotonNetwork.PlayerList[player].SetScore(PhotonNetwork.PlayerList[player].GetScore() + ptsToOther);
			}			
		}
	}
}

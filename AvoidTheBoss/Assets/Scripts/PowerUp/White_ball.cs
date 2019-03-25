using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class White_ball : MonoBehaviour, ObjectAction.IAction
{
	/// <summary>
	/// white ball boule de papier simple.
	/// cost = 0pts
	/// le joueur qui envoie gagne 100 pts
	/// le joueur toucher perd 50 pts
	/// </summary>
	
	private ObjectAction _objectAction;
	private PhotonView _photonView;
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }

	private void Start()
	{
		_objectAction = GetComponent<ObjectAction>();
		_photonView = GetComponent<PhotonView>();
		cost = 0;
		pts = 100;
		ptsToOther = -50;
	}

	public void Action(Collision other)
	{
		print("white ball" + other.gameObject.tag);			
		int player;
		if (int.TryParse(other.gameObject.tag, out player))
		{
			print("player toucher = " + player);
			print("count of player = " + PhotonNetwork.PlayerList.Length);
			print("is local = " + PhotonNetwork.PlayerList[player].IsLocal);
			if (player < PhotonNetwork.PlayerList.Length && !PhotonNetwork.PlayerList[player].IsLocal)
			{
				object com;
				PhotonNetwork.PlayerList[player].CustomProperties.TryGetValue("invincible", out com);
				bool b = (com as bool?) ?? false;
				if (!b)
				{
					_photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
					PhotonNetwork.PlayerList[player].SetScore(PhotonNetwork.PlayerList[player].GetScore() + ptsToOther);
				}
			}			
		}
		else if (other.gameObject.tag.Equals("object"))
		{
			checkObject(other);	
		}
	}

	void checkObject(Collision other)
	{
		PhotonView goPhotonView = other.gameObject.GetComponent<PhotonView>();
		Hashtable hashtable = goPhotonView.Owner.CustomProperties;
		object point;
		if (hashtable.TryGetValue(other.gameObject.name, out point))
		{
			int points = (int) point;
			points--;
			if (points == 0)
				PhotonNetwork.Destroy(other.gameObject);
			hashtable[other.gameObject.name] = points;
		}		
	}
}

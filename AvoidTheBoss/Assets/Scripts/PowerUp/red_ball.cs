using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class red_ball : MonoBehaviour, ObjectAction.IAction {

	
	private PhotonView _photonView;
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }
	
	// Use this for initialization
	void Start () {
		_photonView = GetComponent<PhotonView>();
		cost = 150;
		pts = 0;
		ptsToOther = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Action(Collision other)
	{
		print("red ball !!!");
        
		
		int player;
		if (int.TryParse(other.gameObject.tag, out player))
		{

			if (player < PhotonNetwork.PlayerList.Length && !PhotonNetwork.PlayerList[player].IsLocal)
			{
				object com;
				PhotonNetwork.PlayerList[player].CustomProperties.TryGetValue("invincible", out com);
				bool b = (com as bool?) ?? false;
				if (!b)
				{
					_photonView.RPC("red", other.collider.GetComponent<PhotonView>().Owner);
					_photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
					PhotonNetwork.PlayerList[player].SetScore(PhotonNetwork.PlayerList[player].GetScore() + ptsToOther);
				}
			}			
		}
	}
}

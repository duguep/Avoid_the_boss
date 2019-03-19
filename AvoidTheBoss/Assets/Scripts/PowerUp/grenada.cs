using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class grenada : MonoBehaviour, ObjectAction.IAction {
	
	[SerializeField] private GameObject explodedInk;
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }
	private PhotonView _photonView;
	
	private void Start()
	{
		//_objectAction = GetComponent<ObjectAction>();
		_photonView = GetComponent<PhotonView>();
		cost = 100;
		pts = 0;
		ptsToOther = -50;
	}

	public void Action(Collision other)
	{
		// Explode
		print("Grenada !");
		GameObject explo = PhotonNetwork.Instantiate(explodedInk.name, transform.position, transform.rotation);
		explo.GetComponent<AudioSource>().Play();
		
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

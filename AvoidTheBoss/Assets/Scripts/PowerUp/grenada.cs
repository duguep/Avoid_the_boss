using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class grenada : MonoBehaviour, ObjectAction.IAction {
	
	[SerializeField] private GameObject explodedInk;
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }

	private void Start()
	{
		
	}

	public void Action(Collision other)
	{
		print("Grenada !");

		GameObject explo = PhotonNetwork.Instantiate(explodedInk.name, transform.position, transform.rotation);
		explo.GetComponent<AudioSource>().Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;
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
	[SerializeField] private float timeinvincble;

	public void Action(Collision other)
	{
		StartCoroutine(coffeeactivator());
	}

	IEnumerator coffeeactivator()
	{
		Hashtable hash  = new Hashtable();
		hash.Add("invincible", true);		
		_photonView.Owner.SetCustomProperties(hash);
		yield return new WaitForSeconds(timeinvincble);
		hash.Add("invincible", false);		
		_photonView.Owner.SetCustomProperties(hash);
	}
}

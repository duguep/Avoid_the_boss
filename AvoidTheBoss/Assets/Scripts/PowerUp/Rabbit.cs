using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Rabbit : MonoBehaviour, ObjectAction.IAction
{
	/// <summary>
	/// Rabbit, met en place un lapin et qui rend invicible
	/// cost : 450
	/// le joueur owner : 0
	/// le joueur touché : 0
	/// </summary>

	public GameObject RabbitToSpawn;
	public int cost { get; set; }
	public int pts { get; set; }
	public int ptsToOther { get; set; }
	private PhotonView _photonView;
	[SerializeField] private float timeToInvisible;

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
		StartCoroutine(DontSee());
		_photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
	}
	
	IEnumerator DontSee()
	{
		Hashtable hash = new Hashtable();
		//instantiate Rabbit
		GameObject go = PhotonNetwork.Instantiate(RabbitToSpawn.name, Vector3.zero, Quaternion.identity);

		//set view at the boss
		hash.Add("canSeeByBoss", false);		
		_photonView.Owner.SetCustomProperties(hash);
		
		yield return new WaitForSeconds(timeToInvisible);

		//set view at the boss
		hash.Add("canSeeByBoss", true);		
		_photonView.Owner.SetCustomProperties(hash);

		PhotonNetwork.Destroy(go);
	}
}

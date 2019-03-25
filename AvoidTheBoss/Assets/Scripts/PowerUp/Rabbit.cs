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
		//instantiate Rabbit
		GameObject go = PhotonNetwork.Instantiate(RabbitToSpawn.name, Vector3.zero, Quaternion.identity);

		Hashtable hashtable = _photonView.Owner.CustomProperties;
		//set view at the boss
		if(hashtable.ContainsKey("canSeeByBoss"))
		{
			hashtable["canSeeByBoss"] = false;
		}
		else
		{
			hashtable.Add("canSeeByBoss", false);
		}
		
		yield return new WaitForSeconds(timeToInvisible);

		//set view at the boss
		_photonView.Owner.CustomProperties["canSeeByBoss"] = true;
	
		PhotonNetwork.Destroy(go);
	}
}

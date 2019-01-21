using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
[RequireComponent(typeof(PhotonView))]
public class PowerUpSpawner : MonoBehaviour
{
	public GameObject powerUpPrefabs;

	public GameObject instance = null;

	public PlayerPlace PlayerPlace;
	

	void Update ()
	{
		if (instance == null && PlayerPlace.player != null)
		{
			instance = PhotonNetwork.Instantiate(powerUpPrefabs.name, transform.position, Quaternion.identity);
			if (instance)
				instance.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
		}
	}
}

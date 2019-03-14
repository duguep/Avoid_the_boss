using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class DestroyEx : MonoBehaviour {

	// Use this for initialization
	private void Update()
	{
		if (!GetComponent<AudioSource>().isPlaying)
			PhotonNetwork.Destroy(gameObject);
	}
}

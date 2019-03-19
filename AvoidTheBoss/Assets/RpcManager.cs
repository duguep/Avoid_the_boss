using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RpcManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[PunRPC]
	void ink()
	{
		print("tu t'es pris ink");
	}

	[PunRPC]
	void red()
	{
		print("tu t'es pris Red");
	}

	[PunRPC]
	void alarm()
	{
		print("alarm !! ");
	}
}

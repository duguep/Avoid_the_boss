using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RpcManager : MonoBehaviour
{
	[Tooltip("le temps avec aucun acces au jet")]
	public float timelostThrow = 5f;
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
		StartCoroutine(DontThrow());
	}

	[PunRPC]
	void alarm()
	{
		print("alarm !! ");
		GetComponent<PlayerScore>().toactive = false;
	}
	
	IEnumerator DontThrow()
	{
		OVRGrabber[] grabbers = GetComponentsInChildren<OVRGrabber>();
		grabbers[0].gameObject.SetActive(false);
		grabbers[1].gameObject.SetActive(false);
		yield return new WaitForSeconds(timelostThrow);
		grabbers[0].gameObject.SetActive(true);
		grabbers[1].gameObject.SetActive(true);
	}
}

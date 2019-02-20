using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MoveIA : MonoBehaviour
{
	private int count;
	public GameObject[] pos;
	public GameObject[] interPos;
	private int lastPosIndex;
	
	public NavMeshAgent Boss;

	private Animator _animator;

	private PhotonView _photonView;
	// Use this for initialization
	void Start ()
	{
		
		_animator = GetComponent<Animator>();
		_photonView = GetComponent<PhotonView>();
		//Boss.SetDestination(pos.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool state = Boss.remainingDistance < 1;
		_animator.SetBool("Walk", !state);
		if (state)
			if (lastPosIndex != 0)
				findAndMove();
			else
			{
				Boss.SetDestination(interPos[Random.Range(1, interPos.Length)].transform.position);
				lastPosIndex = -1;
			}
	}

	[PunRPC]
	public void avertBoss(bool state)
	{
		GameObject player = GameObject.Find("LocalAvatar(Clone)");
		if (player)
		{
			player.GetComponent<PlayerScore>().avertBoss(state);
			print(this.gameObject.name +  ": avert bosse warning");			
		}
	}
	
	void findAndMove()
	{
		if (lastPosIndex == -1)
		{
			_photonView.RPC("avertBoss", RpcTarget.All, false);
		}
		int index = Random.Range(0, pos.Length);
		if (count == 0 || index == 0)
		{
			lastPosIndex = index;
			Boss.SetDestination(pos[0].transform.position);
			count = 4;
			_photonView.RPC("avertBoss", RpcTarget.All, true);			
		}
		else if (index != lastPosIndex)
		{		
			lastPosIndex = index;
			Boss.SetDestination(pos[index].transform.position);
			count--;
		}
	}
}

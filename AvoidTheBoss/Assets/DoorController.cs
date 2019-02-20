using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	private Animator _animator;
	// Use this for initialization
	void Start ()
	{
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Boss"))
		{
			_animator.SetBool("IsOpen", true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.Equals("Boss"))
		{
			_animator.SetBool("IsOpen", false);
		}
	}
}

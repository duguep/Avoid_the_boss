using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
	public GameObject powerUpPrefabs;

	private GameObject instance = null;

	void Update ()
	{
		if (instance == null)
			instance = Instantiate(powerUpPrefabs, transform);
	}
}

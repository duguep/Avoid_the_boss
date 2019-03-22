using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class MasterLevel : MonoBehaviour
{

	[SerializeField] private AudioMixer _masterMix;

	public void SetMasterVolume(float vol)
	{
		_masterMix.SetFloat("MasterVolume", vol);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setOVRight : MonoBehaviour
{
	public CurvedUIInputModule CurvedUiInputModule;
	
	// Update is called once per frame
	void Update () {
		if (!CurvedUiInputModule.OculusCameraRig)
			CurvedUiInputModule.OculusCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>();	
	}
}

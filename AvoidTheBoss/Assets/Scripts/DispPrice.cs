using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DispPrice : MonoBehaviour
{
    [SerializeField] private GameObject _panelToDisp;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("name enter = " + other.name);        
        if (other.name == "LeftGrabber" || other.name == "RightGrabber")
            _panelToDisp.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
            _panelToDisp.SetActive(false);
    }
}

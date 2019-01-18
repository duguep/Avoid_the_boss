using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{

	public void ClosePanel(GameObject actualPanel)
	{
		actualPanel.SetActive(false);
	}

	public void OpenPanel(GameObject wantedPanel)
	{
		wantedPanel.SetActive(true);
	}
}

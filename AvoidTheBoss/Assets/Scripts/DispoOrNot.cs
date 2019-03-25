using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispoOrNot : MonoBehaviour
{

	[SerializeField] private GameObject OptionCanvas;
	private bool isDisp = false;

	public void AmIDisp()
	{
		if (OptionCanvas && !isDisp)
		{
			DispMe();
		}
		else if (OptionCanvas && isDisp)
		{
			HideMe();
		}
	}
	
	public void DispMe()
	{
		OptionCanvas.SetActive(true);
		isDisp = true;
	}
	
	public void HideMe()
	{
		OptionCanvas.SetActive(false);
		isDisp = false;
	}
}

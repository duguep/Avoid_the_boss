using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
	public List<Text> playerScore;

	public List<Text> playerName;


	public PlayerPlace place;
	
	// Use this for initialization
	void Start ()
	{
		//PhotonNetwork.LocalPlayer.SetScore(16);	
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
		{
			playerName[i].text = PhotonNetwork.PlayerList[i].NickName;
		}
		
		for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
		{
			playerScore[i].text = PhotonNetwork.PlayerList[i].GetScore().ToString();
		}
		
	}
	
	public void avertBoss(bool state)
	{
		place.setActivePanel(state);
	}
}

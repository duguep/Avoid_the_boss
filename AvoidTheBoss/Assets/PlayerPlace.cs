using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlace : MonoBehaviour
{
    public GameObject player;
    
    public List<Text> ScorePlace;
    public List<Text> NamePLace;

    public GameObject avert1;
    public GameObject avert2;
    public Animator avertBack1;
    public Animator avertBack2;


    private void Start()
    {
        setActivePanel(false);
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
        PlayerScore playerScore = player.GetComponent<PlayerScore>();
        playerScore.place = this;
        playerScore.playerScore = this.ScorePlace;
        playerScore.playerName = this.NamePLace;
    }

    public void setActivePanel(bool state)
    {
        avert1.SetActive(state);
        avert2.SetActive(state);
        avertBack1.SetBool("active", state);
        avertBack2.SetBool("active", state);
    }
}

using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class ink : MonoBehaviour, ObjectAction.IAction {

    private PhotonView _photonView;

    public int cost { get; set; }
    public int pts { get; set; }
    public int ptsToOther { get; set; }

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        cost = 300;
        pts = 0;
        ptsToOther = -50;
    }

    
    public void Action(Collision other)
    {
        print("ink");			
        int player;
        if (int.TryParse(other.gameObject.tag, out player))
        {
            _photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
            if (player <= PhotonNetwork.CountOfPlayersInRooms)
                PhotonNetwork.PlayerList[player].SetScore(PhotonNetwork.PlayerList[player].GetScore() + ptsToOther);
        }
    }
}

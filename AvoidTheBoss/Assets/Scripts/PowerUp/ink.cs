using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class ink : MonoBehaviour, ObjectAction.IAction
{

    /// <summary>
    /// Encre, réduit la visibilté du joueur touché
    /// cost : 50
    /// le joueur owner : 0
    /// le joueur touché : 0
    /// </summary>
    
    private PhotonView _photonView;
    public int cost { get; set; }
    public int pts { get; set; }
    public int ptsToOther { get; set; }

    public GameObject explodedInk;
    
    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        cost = 50;
        pts = 0;
        ptsToOther = 0;
    }

    
    public void Action(Collision other)
    {
        print("ink");

        GameObject explo = PhotonNetwork.Instantiate(explodedInk.name, transform.position, transform.rotation);
        explo.GetComponent<AudioSource>().Play();

        
        //set points
        int player;
        if (int.TryParse(other.gameObject.tag, out player))
        {

            if (player < PhotonNetwork.PlayerList.Length && !PhotonNetwork.PlayerList[player].IsLocal)
            {
                object com;
                PhotonNetwork.PlayerList[player].CustomProperties.TryGetValue("invincible", out com);
                bool b = (com as bool?) ?? false;
                if (!b)
                {
                    // set view
                    _photonView.RPC("Ink", other.collider.GetComponent<PhotonView>().Owner);

                    _photonView.Owner.SetScore(_photonView.Owner.GetScore() + pts);
                    PhotonNetwork.PlayerList[player].SetScore(PhotonNetwork.PlayerList[player].GetScore() + ptsToOther);
                }
            }			
        }
    }
}

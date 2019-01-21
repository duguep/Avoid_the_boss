using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class VRSpawner : MonoBehaviourPunCallbacks, IOnEventCallback

{

   // public GameObject LocalPlayer;    
    string _gameVersion = "1";
    private int indexPos;
    [FormerlySerializedAs("pos")] public Transform[] Pos;
    
    
    // Use this for initialization
    void Start ()
    {
        indexPos = 0;
        Connect();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnConnectedToMaster()
    {
        Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
        Connect();
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
    }

    public void Connect()
    {

        Debug.Log("connect function");

        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("first if");

            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnPhotonRandomJoinFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void  OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    void Awake()
    {


        // #Critical
        // we don't join the lobby. There is no need to join a lobby to get the list of rooms.
        //PhotonNetwork.autoJoinLobby = false;


        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public readonly byte InstantiateVrAvatarEventCode = 123;

    public override void OnJoinedRoom()
    {
        indexPos = PhotonNetwork.CountOfPlayersInRooms;
        print("nbr od player" + indexPos);
        GameObject localAvatar = Instantiate(Resources.Load("LocalAvatar"), Pos[indexPos]) as GameObject;
        PhotonView photonView = localAvatar.GetComponent<PhotonView>();

        if (PhotonNetwork.AllocateViewID(photonView))
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                CachingOption = EventCaching.AddToRoomCache,
                Receivers = ReceiverGroup.Others
            };

            SendOptions sendOptions = new SendOptions
            {
                Reliability = true
            };
            PhotonNetwork.RaiseEvent(InstantiateVrAvatarEventCode, photonView.ViewID, raiseEventOptions, sendOptions);
        }
        else
        {
            Debug.LogError("Failed to allocate a ViewId.");
            Destroy(localAvatar);
        }

    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == InstantiateVrAvatarEventCode)
        {
            GameObject remoteAvatar = Instantiate(Resources.Load("RemoteAvatar")) as GameObject;
            PhotonView photonView = remoteAvatar.GetComponent<PhotonView>();
            photonView.ViewID = (int) photonEvent.CustomData;
        }
    }


}

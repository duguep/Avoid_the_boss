using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SyncServer : MonoBehaviour
{

    PhotonView view;
    // Use this for initialization

    private void Awake()
    {
        GetComponent<PhotonView>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void teleport(RaycastHit hit, float y)
    {
        if (view.IsMine)
        {
            Debug.Log("y = " + y);
            Debug.Log("pose = " + hit.point.ToString());

            transform.position = new Vector3(hit.point.x, 1.3f, hit.point.z);

            transform.eulerAngles = new Vector3(0, y, 0);
            Debug.Log("player  = " + transform.eulerAngles);
            UnityEngine.XR.InputTracking.Recenter();
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}

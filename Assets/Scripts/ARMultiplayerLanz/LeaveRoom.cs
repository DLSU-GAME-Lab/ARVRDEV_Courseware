using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class LeaveRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    
    public void onClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
    }

    public override void OnCreatedRoom()
    {

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed" + message+returnCode);
    }

}

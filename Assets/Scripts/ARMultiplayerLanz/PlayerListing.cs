using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public Player Player { get; private set; }
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        text.text = Player.NickName;
    }

    /*public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }*/
}

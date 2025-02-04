using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.Cockpit;
using System;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerListing playerListing;
    [SerializeField]
    private Button StartGameButton;

    private List<PlayerListing> playerListingList = new List<PlayerListing>();
    /*
     * Populates the scroll view with all the players currently in the room when the current user joins the room
     * Sets the start game button as interactable only for the room creator/master client.
     */
    public override void OnEnable()
    {
        base.OnEnable();
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;
   
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }

        if (PhotonNetwork.IsMasterClient)
        {
            StartGameButton.interactable = true;
        }
    }
    /*
     * Calls the function for creating a new PlayerListing with the information of the new player that had just joined.
     */
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("someone else joined");
        AddPlayerListing(newPlayer);
    }
    /*
     * Removes the content of the scroll view when the current user leaves the room.
     */
    public override void OnLeftRoom()
    {
        content.DestroyChildren();
    }
    /*
     * Destroys the corresponding UI element when a player leaves the room.
     */
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = playerListingList.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(playerListingList[index].gameObject);
            playerListingList.RemoveAt(index);
        }
    }
    /*
     * Creates a new PlayerListing within the UI
     */
    private void AddPlayerListing(Player player)
    {
        PlayerListing listing = PlayerListing.Instantiate(playerListing, content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            playerListingList.Add(listing);
        }
    }
    /*
     * Starts the game by shifting into a different scene. Ensure that the new scene corresponds with 1 within the build menu.
     */
    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel(1);
        }
    }


    

}

using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomViewer : MonoBehaviour
{
    RoomInfo roomData;
    public RoomInfo RoomData
    {
        get { return roomData; }
        set
        {
            roomData = value;
            txtName.text = $"room : {roomData.name}";
            if (roomData.player1 == string.Empty)
            {
                roomData.player1 = "...";
            }
            if (roomData.player2 == string.Empty)
            {
                roomData.player2 = "...";
            }
            txtPlayers.text = $"players : {roomData.player1}, {roomData.player2}";
        }
    }

    public Text txtName;
    public Text txtPlayers;

    public void EnterRoom()
    {
        //K.GetDB().SetListener(SERVER.CallbackType.EnterRoomSuccess, () =>
        //{
        //    print("Enter Room Success");
        //    K.roomData.name = roomData.name;
        //    SceneManager.LoadScene("Room");
        //}).SetListener(SERVER.CallbackType.EnterRoomFail, () =>
        //{
        //    print("Enter Room Fail");
        //}).EnterRoom(roomData.name);
    }
}

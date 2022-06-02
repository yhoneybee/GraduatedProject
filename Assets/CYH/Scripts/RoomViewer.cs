using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public struct RoomData
{
    public string name;
    public string player1;
    public string player2;
}

public class RoomViewer : MonoBehaviour
{
    RoomData roomData;
    public RoomData RoomData
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
        K.GetDB().SetListener(SERVER.CallbackType.EnterRoomSuccess, () =>
        {
            print("Enter Room Success");
            K.enteredRoomName = roomData.name;
            SceneManager.LoadScene("Room");
        }).SetListener(SERVER.CallbackType.EnterRoomFail, () =>
        {
            print("Enter Room Fail");
        }).EnterRoom(roomData.name);
    }
}

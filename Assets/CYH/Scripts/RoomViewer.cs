using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomViewer : MonoBehaviour
{
    RoomInfo roomInfo;
    public RoomInfo RoomInfo
    {
        get { return roomInfo; }
        set
        {
            roomInfo = value;
            txtName.text = $"{roomInfo.name}";
            if (roomInfo.player1 == string.Empty)
            {
                roomInfo.player1 = "...";
            }
            if (roomInfo.player2 == string.Empty)
            {
                roomInfo.player2 = "...";
            }
            txtPlayers.text = $"{roomInfo.player1}, {roomInfo.player2}";
        }
    }

    public Text txtName;
    public Text txtPlayers;

    public void EnterRoom()
    {
        REQ_CreateEnterRoom req = new REQ_CreateEnterRoom();
        req.roomName = roomInfo.name;

        K.Send(PacketType.REQ_ENTER_ROOM_PACKET, req);
    }
}

using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateRoomLinker : MonoBehaviour
{
    public InputField inputRoomName;

    public void CreateRoom()
    {
        REQ_CreateEnterRoom req = new REQ_CreateEnterRoom();
        req.roomName = inputRoomName.text;
        
        K.Send(PacketType.REQ_CREATE_ROOM_PACKET, req);
    }
}

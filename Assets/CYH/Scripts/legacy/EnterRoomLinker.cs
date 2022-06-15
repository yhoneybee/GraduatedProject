using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnterRoomLinker : MonoBehaviour
{
    public InputField inputRoomName;

    public void EnterRoom()
    {
        REQ_CreateEnterRoom req = new REQ_CreateEnterRoom();
        req.roomName = inputRoomName.text;

        Packet packet = new Packet();
        packet.SetData(PacketType.REQ_ENTER_ROOM_PACKET, Data<REQ_CreateEnterRoom>.Serialize(req));

        Network.Instance.Send(packet);
    }
}

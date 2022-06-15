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
        
        Packet packet = new Packet();
        packet.SetData(PacketType.REQ_CREATE_ROOM_PACKET, Data<REQ_CreateEnterRoom>.Serialize(req));

        Network.Instance.Send(packet);

        Network.Instance.gamePackHandler.RES_CreateRoom = (packet) =>
        {
        };

        Network.Instance.gamePackHandler.RES_EnterRoom = (packet) =>
        {
            var res = packet.GetPacket<RES_EnterRoom>();
            Debug.Log(res.reason);
            if (!res.completed) return;

            SceneManager.LoadScene("Room");
        };
    }
}

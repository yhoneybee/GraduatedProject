using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class GamePacketHandler : MonoBehaviour
{
    Network network;

    public void Init(Network network)
    {
        this.network = network;
    }

    public void ParsePacket(Packet packet)
    {
        switch ((PacketType)packet.type)
        {
            case PacketType.CHAT_PACKET:
                ChatPacketRes(packet);
                break;
            case PacketType.END:
                break;
        }
    }

    public void ChatPacketRes(Packet packet)
    {
        ChatPacket chat = Data<ChatPacket>.Deserialize(packet.data);

        Debug.Log($"{chat.id} : {chat.chat}");
    }
}

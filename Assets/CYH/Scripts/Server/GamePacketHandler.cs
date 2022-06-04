using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePacketHandler
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
                ChatPacket(packet);
                break;
            case PacketType.END:
                break;
        }
    }


    public void ChatPacket(Packet packet)
    {
        ChatPacket notify = Data<ChatPacket>.Deserialize(packet.data);
    }
}

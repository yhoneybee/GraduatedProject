using MyPacket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePacketHandler
{
    Network network;

    public static Action<ChatPacket> onChatPacket;

    public void Init(Network network)
    {
        this.network = network;
    }

    public void ParsePacket(Packet packet)
    {
        switch ((PacketType)packet.type)
        {
            case PacketType.LOGIN_PACKET:
                break;
            case PacketType.CHAT_PACKET:
                onChatPacket?.Invoke(Data<ChatPacket>.Deserialize(packet.data));
                break;
            case PacketType.CHARACTOR_PACKET:
                break;
            case PacketType.END:
                break;
        }
    }
}

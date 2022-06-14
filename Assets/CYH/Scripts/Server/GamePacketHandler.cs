using MyPacket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePacketHandler
{
    public Action<Packet> RES_Signin;
    public Action<Packet> RES_Login;

    Network network;

    public void Init(Network network)
    {
        this.network = network;
    }

    public void ParsePacket(Packet packet)
    {
        switch ((PacketType)packet.type)
        {
            case PacketType.CONNECTED:
                Connected(packet);
                break;
            case PacketType.RES_SIGNIN_PACKET:
                RES_Signin(packet);
                break;
            case PacketType.RES_LOGIN_PACKET:
                RES_Login(packet);
                Login(packet);
                break;
            case PacketType.RES_CREATE_ROOM_PACKET:
                break;
            case PacketType.RES_ENTER_ROOM_PACKET:
                break;
            case PacketType.RES_LEAVE_ROOM_PACKET:
                break;
            case PacketType.RES_ROOMS_PACKET:
                break;
            case PacketType.RES_USER_PACKET:
                User(packet);
                break;
            case PacketType.RES_READY_GAME_PACKET:
                break;
            case PacketType.RES_START_GAME_PACKET:
                break;
            case PacketType.RES_GAME_WIN_PACKET:
                break;
            case PacketType.RES_GAME_LOSE_PACKET:
                break;
            case PacketType.RES_CHAT_PACKET:
                break;
            case PacketType.RES_CHARACTOR_PACKET:
                break;
            case PacketType.RES_LOGOUT_PACKET:
                break;
            case PacketType.DISCONNECTED:
                break;
            case PacketType.END:
                break;
        }
    }

    private void User(Packet packet)
    {
        var res = packet.GetPacket<RES_User>();
        if (res == null || !res.completed) return;

        K.userInfo = res.userInfo;
    }

    private void Login(Packet packet)
    {
        var res = packet.GetPacket<RES>();
        if (res == null || !res.completed) return;

        REQ_User req = new REQ_User();
        req.id = K.userInfo.id;

        Packet packet2 = new Packet();
        packet2.SetData(PacketType.REQ_USER_PACKET, Data<REQ_User>.Serialize(req));

        Network.Instance.Send(packet2);
    }

    private void Connected(Packet packet)
    {
        var res = packet.GetPacket<RES>();
        if (res == null || !res.completed) return;
        SceneManager.LoadScene("Title");
    }
}

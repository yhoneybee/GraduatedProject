using MyPacket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePacketHandler
{
    public Action<Packet> RES_Signin;
    public Action<Packet> RES_Login;
    public Action<Packet> RES_CreateRoom;
    public Action<Packet> RES_EnterRoom;
    public Action<Packet> RES_OtherUserEnterRoom;
    public Action<Packet> RES_LeaveRoom;
    public Action<Packet> RES_OtherUserLeaveRoom;
    public Action<Packet> RES_Rooms;
    public Action<Packet> RES_User;
    public Action<Packet> RES_ReadyGame;
    public Action<Packet> RES_StartGame;
    public Action<Packet> RES_GameEnd;
    public Action<Packet> RES_Chat;
    public Action<Packet> RES_Charactor;
    public Action<RES_GameTime> RES_GameTime;
    public Action<Packet> RES_Select;
    public Action<Packet> RES_Logout;

    Network network;

    public void Init(Network network)
    {
        this.network = network;
    }

    public void ParsePacket(Packet packet)
    {
        switch ((PacketType)packet.type)
        {
            case PacketType.RES_CONNECTED:
                Connected(packet);
                break;
            case PacketType.RES_SIGNIN_PACKET:
                RES_Signin?.Invoke(packet);
                break;
            case PacketType.RES_LOGIN_PACKET:
                RES_Login?.Invoke(packet);
                Login(packet);
                break;
            case PacketType.RES_CREATE_ROOM_PACKET:
                CreateRoom(packet);
                RES_CreateRoom?.Invoke(packet);
                break;
            case PacketType.RES_ENTER_ROOM_PACKET:
                EnterRoom(packet);
                RES_EnterRoom?.Invoke(packet);
                break;
            case PacketType.RES_OTHER_USER_ENTER_ROOM_PACKET:
                OtherUserEnterRoom(packet);
                RES_OtherUserEnterRoom?.Invoke(packet);
                break;
            case PacketType.RES_LEAVE_ROOM_PACKET:
                RES_LeaveRoom?.Invoke(packet);
                break;
            case PacketType.RES_OTHER_USER_LEAVE_ROOM_PACKET:
                RES_OtherUserLeaveRoom?.Invoke(packet);
                break;
            case PacketType.RES_ROOMS_PACKET:
                RES_Rooms?.Invoke(packet);
                break;
            case PacketType.RES_USER_PACKET:
                User(packet);
                RES_User?.Invoke(packet);
                break;
            case PacketType.RES_READY_GAME_PACKET:
                Ready(packet);
                RES_ReadyGame?.Invoke(packet);
                break;
            case PacketType.RES_START_GAME_PACKET:
                StartGame(packet);
                RES_StartGame?.Invoke(packet);
                break;
            case PacketType.RES_GAME_END_PACKET:
                GameEnd(packet);
                RES_GameEnd?.Invoke(packet);
                break;
            case PacketType.RES_CHAT_PACKET:
                RES_Chat?.Invoke(packet);
                break;
            case PacketType.RES_SELECTCHARACTOR:
                RES_Select?.Invoke(packet);
                break;
            case PacketType.RES_CHARACTOR_PACKET:
                RES_Charactor?.Invoke(packet);
                break;
            case PacketType.RES_GAME_TIME_PACKET:
                var res = packet.GetPacket<RES_GameTime>();
                if (res == null || !res.completed) break;
                RES_GameTime?.Invoke(res);
                break;
            case PacketType.RES_LOGOUT_PACKET:
                Logout(packet);
                RES_Logout?.Invoke(packet);
                break;
            case PacketType.RES_DISCONNECTED:
                Disconnected(packet);
                break;
            case PacketType.END:
                break;
        }
    }

    private void GameEnd(Packet packet)
    {
        var res = packet.GetPacket<RES>();
        if (res == null || !res.completed) return;

        SceneManager.LoadScene("Main");
    }

    private void Logout(Packet packet)
    {
        var res = packet.GetPacket<RES>();
        if (res == null || !res.completed) return;
    }

    private void Ready(Packet packet)
    {
        //REQ req = new REQ();
        //req.what = "게임 시작 조건 검사";

        //K.Send(PacketType.REQ_START_GAME_PACKET, req);
    }

    private void StartGame(Packet packet)
    {
        Debug.Log("START GAME");
        V.playerNumber = packet.GetPacket<RES_StartGame>().playerNum;
        SceneManager.LoadScene("Ingame");
    }

    private void OtherUserEnterRoom(Packet packet)
    {

    }

    private void EnterRoom(Packet packet)
    {
        var res = packet.GetPacket<RES_EnterRoom>();
        if (res == null || !res.completed) return;

        K.roomInfo = res.roomInfo;
        K.player1 = res.player1;
        K.player2 = res.player2;

        Debug.Log($"{K.roomInfo.name} / {K.roomInfo.player1}, {K.player1.id}/ {K.roomInfo.player2}, {K.player2.id}");

        //REQ_User req = new REQ_User();
        //req.id = K.roomInfo.player1;
        //K.Send(PacketType.REQ_USER_PACKET, req);
        //req.id = K.roomInfo.player2;
        //K.Send(PacketType.REQ_USER_PACKET, req);
    }

    private void CreateRoom(Packet packet)
    {
        var res = packet.GetPacket<RES_CreateRoom>();
        if (res == null || !res.completed) return;

        REQ_CreateEnterRoom req = new REQ_CreateEnterRoom();
        req.roomName = res.roomName;

        K.Send(PacketType.REQ_ENTER_ROOM_PACKET, req);
    }

    private void Disconnected(Packet packet)
    {
        var res = packet.GetPacket<RES>();
        if (res == null || !res.completed) return;

        Application.Quit();
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

        K.Send(PacketType.REQ_USER_PACKET, req);
    }

    private void Connected(Packet packet)
    {
        var res = packet.GetPacket<RES>();
        if (res == null || !res.completed) return;
        Network.Instance.onConnect?.Invoke();
    }
}

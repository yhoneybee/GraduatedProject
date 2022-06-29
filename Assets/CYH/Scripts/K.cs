using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using MyPacket;

public static class K
{
    public static UserInfo userInfo;
    public static UserInfo player1;
    public static UserInfo player2;
    public static RoomInfo roomInfo;
    public static CharactorType player1Type;
    public static CharactorType player2Type;
    public static bool host;

    public static string SHA256(string data)
    {
        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
        StringBuilder stringBuilder = new StringBuilder();
        foreach (byte b in hash)
        {
            stringBuilder.AppendFormat("{0:x2}", b);
        }
        return stringBuilder.ToString();
    }

    public static void Logout()
    {
        REQ req = new REQ();
        req.what = "Logout";

        Send(PacketType.REQ_LOGOUT_PACKET, req);
    }

    public static void QuitGame()
    {
        REQ req = new REQ();
        req.what = "Disconnected";

        Send(PacketType.REQ_DISCONNECTED, req);
    }

    public static void PositionUpdate(REQ_RES_Charactor req)
    {
        Send(PacketType.REQ_CHARACTOR_PACKET, req);
    }

    public static void Send<T>(PacketType packetType, T req)
        where T : new()
    {
        Packet packet = new Packet();
        packet.SetData(packetType, Data<T>.Serialize(req));
        Network.Instance.Send(packet);
    }

    public static void LeaveRoom()
    {
        if (roomInfo.name == string.Empty) return;

        roomInfo = new RoomInfo();

        REQ req = new REQ();
        req.what = "LeaveRoom";

        Send(PacketType.REQ_LEAVE_ROOM_PACKET, req);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using MyPacket;

public static class K
{
    public static UserInfo userInfo;
    public static RoomInfo roomInfo;

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

    public static void QuitGame()
    {
        REQ req = new REQ();
        req.what = "Disconnected";
        var data = Data<REQ>.Serialize(req);

        Packet packet = new Packet();
        packet.SetData(PacketType.DISCONNECTED, data, data.Length);

        Network.Instance.Send(packet);
    }
}

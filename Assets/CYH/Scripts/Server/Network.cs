using MyPacket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Network : MonoBehaviour
{
    Socket socket;
    SocketAsyncEventArgs receiveEventArgs;
    MessageResolver messageResolver;
    LinkedList<Packet> receviePacketList;
    GamePacketHandler gamePackHandler;
    byte[] receiveBuffer;
    object mutexReceivePacketList = new object();

    public void Init()
    {
        receviePacketList = new LinkedList<Packet>();
        receiveBuffer = new byte[Defines.SOCKET_BUFFER_SIZE];
        messageResolver = new MessageResolver();

        gamePackHandler = new GamePacketHandler();
        gamePackHandler.Init(this);

        receiveEventArgs = new SocketAsyncEventArgs();
        receiveEventArgs.Completed += OnReceiveCompleted;
        receiveEventArgs.UserToken = this;
        receiveEventArgs.SetBuffer(receiveBuffer, 0, 1024 * 4);
    }


    public void StartReceive()
    {
        bool pending = socket.ReceiveAsync(receiveEventArgs);
        if (!pending)
            OnReceiveCompleted(this, receiveEventArgs);
    }


    void OnReceiveCompleted(object sender, SocketAsyncEventArgs e)
    {
        if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
        {
            messageResolver.OnReceive(e.Buffer, e.Offset, e.BytesTransferred, OnMessageCompleted);

            StartReceive();
        }
        else
        {

        }
    }

    void OnMessageCompleted(Packet packet)
    {
        PushPacket(packet);
    }

    void PushPacket(Packet packet)
    {
        lock(mutexReceivePacketList)
        {
            receviePacketList.AddLast(packet);
        }
    }

    public void ProcessPackets()
    {
        lock (mutexReceivePacketList)
        {
            foreach (var packet in receviePacketList)
            {
                gamePackHandler.ParsePacket(packet);
            }
            receviePacketList.Clear();
        }
    }

    public Network()
    {

    }

    private void Start()
    {
        Init();
        Connect("127.0.0.1", 6475);
        ChatPacket chatPacket = new ChatPacket();
        chatPacket.id = "kkulbeol";
        chatPacket.chat = "fdsjfdsjfksdjfk";
        chatPacket.chatType = ((short)ChatType.ALL);
        var buffer = Data<ChatPacket>.Serialize(chatPacket);

        ChatPacket temp = Data<ChatPacket>.Deserialize(buffer);

        Packet packet = new Packet();
        packet.type = (short)PacketType.CHAT_PACKET;
        packet.SetData(buffer, buffer.Length);
        Send(packet);
    }

    private void Update()
    {
        ProcessPackets();
    }

    public void Connect(string address, int port)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.NoDelay = true;

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(address), port);

        SocketAsyncEventArgs eventArgs = new SocketAsyncEventArgs();
        eventArgs.Completed += OnConnected;
        eventArgs.RemoteEndPoint = endPoint;

        bool pending = socket.ConnectAsync(eventArgs);
        if (!pending)
            OnConnected(null, eventArgs);
    }

    void OnConnected(object sender, SocketAsyncEventArgs e)
    {
        if (e.SocketError == SocketError.Success)
        {

        }
        else
        {

        }
    }

    public void Send(Packet packet)
    {
        if (socket == null || !socket.Connected) return;

        SocketAsyncEventArgs sendEventArgs = SocketAsyncEventArgsPool.Instance.Pop();
        sendEventArgs.Completed += OnSendCompleted;
        sendEventArgs.UserToken = this;

        byte[] sendData = GetSendBytesA(packet);
        sendEventArgs.SetBuffer(sendData, 0, sendData.Length);

        bool pending = socket.SendAsync(sendEventArgs);
        if (!pending)
            OnSendCompleted(null, sendEventArgs);
    }

    /// <summary>
    /// TEMP
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public byte[] GetSendBytesA(Packet packet)
    {
        byte[] type_bytes = BitConverter.GetBytes(packet.type);
        int header_size = packet.data.Length;
        byte[] header_bytes = BitConverter.GetBytes(header_size);
        byte[] send_bytes = new byte[header_bytes.Length + type_bytes.Length + packet.data.Length];

        Array.Copy(header_bytes, 0, send_bytes, 0, header_bytes.Length);
        Array.Copy(type_bytes, 0, send_bytes, header_bytes.Length, type_bytes.Length);
        Array.Copy(packet.data, 0, send_bytes, header_bytes.Length + type_bytes.Length, packet.data.Length);

        return send_bytes;
    }

    void OnSendCompleted(object sender, SocketAsyncEventArgs e)
    {
        if (e.SocketError == SocketError.Success)
        {

        }
        else
        {

        }

        e.Completed -= OnSendCompleted;
        SocketAsyncEventArgsPool.Instance.Push(e);
    }
}

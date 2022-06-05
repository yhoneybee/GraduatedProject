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
        Connect("119.196.245.41", 6475);
        StartReceive();
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

        byte[] sendData = packet.GetSendBytes();
        sendEventArgs.SetBuffer(sendData, 0, sendData.Length);

        bool pending = socket.SendAsync(sendEventArgs);
        if (!pending)
            OnSendCompleted(null, sendEventArgs);
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

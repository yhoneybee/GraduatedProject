using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;

public class Network : MonoBehaviour
{
    Socket socket;
    SocketAsyncEventArgs receiveEventArgs;
    MessageResolver messageResolver;
    LinkedList<Packet> receivePacketList;
    Mutex mutexReceivePacketList;
    GamePacketHandler gamePacketHandler;
    byte[] receiveBuffer;

    public Network() { }

    public void Init()
    {
        receivePacketList = new LinkedList<Packet>();
        receiveBuffer = new byte[Defines.SOCKET_BUFFER_SIZE];
        messageResolver = new MessageResolver();

        gamePacketHandler = new GamePacketHandler();
        gamePacketHandler.Init(this);

        receiveEventArgs = new SocketAsyncEventArgs();
        receiveEventArgs.Completed += OnReceiveCompleted;
        receiveEventArgs.UserToken = this;
        receiveEventArgs.SetBuffer(receiveBuffer, 0, Defines.SOCKET_DIVISION_SIZE);
    }

    public void StartReceive()
    {
        bool pending = socket.ReceiveAsync(receiveEventArgs);
        if (!pending) OnReceiveCompleted(this, receiveEventArgs);
    }

    private void OnReceiveCompleted(object sender, SocketAsyncEventArgs e)
    {
        if (e.SocketError == SocketError.Success && 0 < e.BytesTransferred)
        {
            messageResolver.OnReceive(e.Buffer, e.Offset, e.BytesTransferred, OnMessageCompleted);

            StartReceive();
        }
        else
        {

        }
    }

    private void OnMessageCompleted(Packet packet)
    {
        PushPacket(packet);
    }

    private void PushPacket(Packet packet)
    {
        lock (mutexReceivePacketList)
        {
            receivePacketList.AddLast(packet);
        }
    }

    public void ProcessPackets()
    {
        lock (mutexReceivePacketList)
        {
            foreach (Packet packet in receivePacketList)
                gamePacketHandler.ParsePacket(packet);
            receivePacketList.Clear();
        }
    }

    public void Connect(string ip, int port)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.NoDelay = true;

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

        SocketAsyncEventArgs eventArgs = new SocketAsyncEventArgs();
        eventArgs.Completed += OnConnected;
        eventArgs.RemoteEndPoint = endPoint;

        bool pending = socket.ConnectAsync(eventArgs);
        if (!pending) OnConnected(null, eventArgs);
    }

    private void OnConnected(object sender, SocketAsyncEventArgs e)
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

        byte[] sendData = packet.GetSendBytes();
        sendEventArgs.SetBuffer(sendData, 0, sendData.Length);

        bool pending = socket.SendAsync(sendEventArgs);
        if (!pending) OnSendCompleted(null, sendEventArgs);
    }

    private void OnSendCompleted(object sender, SocketAsyncEventArgs e)
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

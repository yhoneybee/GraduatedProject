using MyPacket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatLinker : MonoBehaviour
{
    public RectTransform rtrnContent;
    public Text txtChatOrigin;

    public ScrollRect scrollChat;
    public InputField inputChat;
    public Button btnSendChat;

    private void Start()
    {
        btnSendChat.onClick.AddListener(SendChat);

        GamePacketHandler.onChatPacket = OnChat;
    }

    private void OnChat(ChatPacket chat)
    {
        var obj = Instantiate(txtChatOrigin, rtrnContent);
        obj.text = $"[{chat.chatType}] {chat.id} : {chat.chat}";
    }

    private void SendChat()
    {
        ChatPacket chatPacket = new ChatPacket();
        chatPacket.chatType = ChatType.ALL;
        chatPacket.id = K.loginedId;
        chatPacket.to = "";
        chatPacket.chat = inputChat.text;
        byte[] buffer = Data<ChatPacket>.Serialize(chatPacket);

        Packet packet = new Packet();
        packet.type = ((short)PacketType.CHAT_PACKET);
        packet.SetData(buffer, buffer.Length);

        Network.Instance.Send(packet);
    }
}

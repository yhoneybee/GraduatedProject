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

        Network.Instance.gamePackHandler.RES_Chat = (packet) =>
        {
            var res = packet.GetPacket<REQ_RES_Chat>();

            var obj = Instantiate(txtChatOrigin, rtrnContent);

            if (res.to == "ALL") obj.color = Color.black;
            else obj.color = Color.gray;

            obj.text = $"{res.id} : {res.chat}";
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            btnSendChat.onClick.Invoke();
            inputChat.Select();
        }
    }

    private void SendChat()
    {
        if (inputChat.text == string.Empty) return;

        REQ_RES_Chat req = new REQ_RES_Chat();
        req.id = K.userInfo.id;
        req.to = "ALL";
        req.chat = inputChat.text;

        K.Send(PacketType.REQ_CHAT_PACKET, req);

        inputChat.text = string.Empty;
        scrollChat.verticalScrollbar.value = 0;
    }
}

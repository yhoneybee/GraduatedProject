using MyPacket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomLinker : MonoBehaviour
{
    public Text txtRoomName;
    public Button btnReady;
    public Button btnStart;
    public Text txtBtnReady;
    public PlayerSlot player1Slot;
    public PlayerSlot player2Slot;
    public SelectLinker select0;
    public SelectLinker select1;

    private void Start()
    {
        btnStart.gameObject.SetActive(K.host);
        txtRoomName.text = $"{K.roomInfo.name}";
        btnReady.onClick.AddListener(ReadyGame);
        btnStart.onClick.AddListener(StartGame);

        player1Slot.Set(K.player1);
        player2Slot.Set(K.player2);

        Network.Instance.gamePackHandler.RES_LeaveRoom = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            if (!res.completed) return;

            //SceneManager.LoadScene("Main");
            if (Title.Instance != null)
            {
                Title.Instance.ChangeScene("Main");
            }
            else if (Ingame.Instance != null)
            {
                Ingame.Instance.ChangeScene("Main");
            }
        };

        Network.Instance.gamePackHandler.RES_ReadyGame = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            if (res == null || !res.completed) return;

            var split = res.reason.Split(',');

            player1Slot.txtReady.text = split[0] == "True" ? "준비 중" : "대기 중";
            player2Slot.txtReady.text = split[1] == "True" ? "준비 중" : "대기 중";
        };

        Network.Instance.gamePackHandler.RES_Select = (packet) =>
        {
            var res = packet.GetPacket<REQ_RES_Select>();

            if (K.roomInfo.player1 == K.userInfo.id)
            {
                K.player2Type = res.charactorType;
                select1.ButtonColorChange(K.player2Type);
            }
            else
            {
                K.player1Type = res.charactorType;
                select0.ButtonColorChange(K.player1Type);
            }
        };

        Network.Instance.gamePackHandler.RES_OtherUserEnterRoom = (packet) =>
        {
            RefreshPlayerSlot(packet);
        };

        Network.Instance.gamePackHandler.RES_OtherUserLeaveRoom = (packet) =>
        {
            RefreshPlayerSlot(packet);
        };
    }

    private void RefreshPlayerSlot(Packet packet)
    {
        var res = packet.GetPacket<RES_OtherUser>();
        if (res == null || !res.completed) return;

        player1Slot.Set(res.player1);
        player2Slot.Set(res.player2);
    }

    private void StartGame()
    {
        REQ req = new REQ();
        req.what = "Start";

        K.Send(PacketType.REQ_START_GAME_PACKET, req);
    }

    public void ReadyGame()
    {
        REQ req = new REQ();
        req.what = "Ready";

        txtBtnReady.text = txtBtnReady.text == "준비" ? "취소" : "준비";

        K.Send(PacketType.REQ_READY_GAME_PACKET, req);
    }

    public void LeaveRoom()
    {
        K.LeaveRoom();
    }
}

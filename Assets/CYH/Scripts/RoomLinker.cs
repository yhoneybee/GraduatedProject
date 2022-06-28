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

    private void Start()
    {
        btnStart.gameObject.SetActive(K.host);
        txtRoomName.text = $"room : {K.roomInfo.name}";
        btnReady.onClick.AddListener(ReadyGame);
        btnStart.onClick.AddListener(StartGame);

        player1Slot.Set(K.player1);
        player2Slot.Set(K.player2);

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

        txtBtnReady.text = txtBtnReady.text == "Ready" ? "Cancel" : "Ready";

        K.Send(PacketType.REQ_READY_GAME_PACKET, req);
    }

    public void LeaveRoom()
    {
        K.LeaveRoom();

        Network.Instance.gamePackHandler.RES_LeaveRoom = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            if (!res.completed) return;

            SceneManager.LoadScene("Main");
        };
    }
}

using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomLinker : MonoBehaviour
{
    public Text txtRoomName;
    public Button btnReady;
    public Text txtBtnReady;

    private void Start()
    {
        txtRoomName.text = $"room : {K.roomInfo.name}";
        btnReady.onClick.AddListener(Ready);
    }

    public void Ready()
    {
        REQ req = new REQ();
        req.what = "Ready";

        K.Send(PacketType.REQ_READY_GAME_PACKET, req);

        Network.Instance.gamePackHandler.RES_ReadyGame = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            if (!res.completed) return;

            txtBtnReady.text = "On Ready";

            if (res.reason == "ÁØºñ ¾ÈµÊ")
            {
                txtBtnReady.text = "To Ready";
            }
        };
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

    private void OnApplicationQuit()
    {
        LeaveRoom();
    }
}

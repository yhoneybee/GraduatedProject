using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomLinker : MonoBehaviour
{
    public Text txtRoomName;
    public Button btnReady;

    private void Start()
    {
        txtRoomName.text = $"room : {K.roomData.name}";
        btnReady.onClick.AddListener(Ready);
    }

    public void Ready()
    {
        K.GetDB().SetListener(SERVER.CallbackType.ReadySuccess, () =>
        {
            print("ready success");
        }).SetListener(SERVER.CallbackType.ReadyFail, () =>
        {
            print("ready fail");
        }).Ready(K.loginedId);
    }

    private void OnApplicationQuit()
    {
        QuitRoom();
    }

    public void QuitRoom()
    {
        K.GetDB().SetListener(SERVER.CallbackType.QuitRoomSuccess, () =>
        {
            SceneManager.LoadScene("Main");
        }).SetListener(SERVER.CallbackType.QuitRoomFail, () =>
        {

        }).QuitRoom(K.roomData.name);
    }
}

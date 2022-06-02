using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomLinker : MonoBehaviour
{
    public Text txtRoomName;

    private void Start()
    {
        txtRoomName.text = $"room : {K.enteredRoomName}";
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

        }).QuitRoom(K.enteredRoomName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLinker : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        QuitRoom();
    }

    public void QuitRoom()
    {
        K.GetDB().SetListener(SERVER.CallbackType.QuitRoomSuccess, () =>
        {

        }).SetListener(SERVER.CallbackType.QuitRoomFail, () =>
        {

        }).QuitRoom(K.enteredRoomName);
    }
}

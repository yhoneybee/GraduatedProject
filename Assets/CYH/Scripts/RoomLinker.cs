using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLinker : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        K.GetDB().SetListener(SERVER.CallbackType.QuitRoomSuccess, () =>
        {

        }).SetListener(SERVER.CallbackType.QuitRoomFail, () => 
        {

        }).QuitRoom(K.enteredRoomName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoomLinker : MonoBehaviour
{
    private void Start()
    {
        CreateRoom();
    }

    public void CreateRoom()
    {
        K.GetDB().SetListener(SERVER.CallbackType.CreateRoomSuccess, () =>
        {
            print("CREATE SUCCESS");
        }).SetListener(SERVER.CallbackType.CreateRoomFail, () =>
        {
            print("CREATE FAIL");
        }).CreateRoom();
    }
}

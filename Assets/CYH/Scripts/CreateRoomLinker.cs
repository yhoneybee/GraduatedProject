using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateRoomLinker : MonoBehaviour
{
    public InputField inputRoomName;

    public void CreateRoom()
    {
        K.GetDB().SetListener(SERVER.CallbackType.CreateRoomSuccess, () =>
        {
            print("CREATE SUCCESS");
            K.enteredRoomName = inputRoomName.text;
            SceneManager.LoadScene("Room");
        }).SetListener(SERVER.CallbackType.CreateRoomFail, () =>
        {
            print("CREATE FAIL");
        }).CreateRoom(inputRoomName.text);
    }
}

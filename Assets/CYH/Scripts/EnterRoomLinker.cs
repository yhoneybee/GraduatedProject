using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterRoomLinker : MonoBehaviour
{
    public InputField inputRoomName;

    public void EnterRoom()
    {
        K.GetDB().SetListener(SERVER.CallbackType.EnterRoomSuccess, () =>
        {
            print("Enter Room Success");
            K.enteredRoomName = inputRoomName.text;
            SceneManager.LoadScene("Room");
        }).SetListener(SERVER.CallbackType.EnterRoomFail, () => 
        {
            print("Enter Room Fail");
        }).EnterRoom(inputRoomName.text);
    }
}

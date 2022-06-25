using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLinker : MonoBehaviour
{
    private void Start()
    {
        Network.Instance.gamePackHandler.RES_EnterRoom = (packet) =>
        {
            var res = packet.GetPacket<RES_EnterRoom>();
            if (!res.completed) return;

            SceneManager.LoadScene("Room");
        };
    }

    public void Back()
    {
        SceneManager.LoadScene("Title");
        K.Logout();
    }
}

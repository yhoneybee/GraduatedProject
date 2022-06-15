using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using MyPacket;

[Serializable]
public struct LoginInfo
{
    public string id;
    public string pw;
    public bool remember;
}

public class LoginLinker : MonoBehaviour
{
    public InputField inputID;
    public InputField inputPW;
    public Toggle toggleRemember;
    public Button btnLogin;

    readonly string saveFileName = "Remember.json";

    private void Start()
    {
        btnLogin.onClick.AddListener(Login);

        inputID.text = "";
        inputPW.text = "";

        if (Json.HasFile(saveFileName))
        {
            LoginInfo info = Json.Read<LoginInfo>(saveFileName);
            inputID.text = info.id;
            inputPW.text = info.pw;
            toggleRemember.isOn = info.remember;
        }
    }

    public void Login()
    {
        REQ_Login req = new REQ_Login();
        req.id = inputID.text;
        req.pw = inputPW.text;

        Packet packet = new Packet();
        packet.SetData(PacketType.REQ_LOGIN_PACKET, Data<REQ_Login>.Serialize(req));

        Network.Instance.Send(packet);

        Network.Instance.gamePackHandler.RES_Login = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            Debug.Log(res.reason);
            if (!res.completed) return;

            if (toggleRemember.isOn)
            {
                Json.Write(new LoginInfo { id = inputID.text, pw = inputPW.text, remember = true }, saveFileName);
            }
            else
            {
                Json.Write(new LoginInfo { remember = false }, saveFileName);
            }

            K.userInfo.id = inputID.text;

            SceneManager.LoadScene("Main");
        };
    }
}

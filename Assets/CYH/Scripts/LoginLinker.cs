using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using MyPacket;
using UnityEngine.EventSystems;

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
    public InputField inputPw;
    public Toggle toggleRemember;
    public Button btnLogin;
    public Button btnToSign;

    readonly string saveFileName = "Remember.json";

    private void OnEnable()
    {
        inputID.Select();
    }

    private void OnDisable()
    {
        inputID.text = string.Empty;
        inputPw.text = string.Empty;
    }

    private void Start()
    {
        btnLogin.onClick.AddListener(Login);

        inputID.text = "";
        inputPw.text = "";

        if (Json.HasFile(saveFileName))
        {
            LoginInfo info = Json.Read<LoginInfo>(saveFileName);
            inputID.text = info.id;
            inputPw.text = info.pw;
            toggleRemember.isOn = info.remember;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                var prev = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                if (prev != null) prev.Select();
            }
            else
            {
                var next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                if (next != null) next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            btnLogin.onClick.Invoke();
        }
    }

    public void Login()
    {
        REQ_Login req = new REQ_Login();
        req.id = inputID.text;
        req.pw = inputPw.text;

        K.Send(PacketType.REQ_LOGIN_PACKET, req);

        Network.Instance.gamePackHandler.RES_Login = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            if (!res.completed) return;

            if (toggleRemember.isOn)
            {
                Json.Write(new LoginInfo { id = inputID.text, pw = inputPw.text, remember = true }, saveFileName);
            }
            else
            {
                Json.Write(new LoginInfo { remember = false }, saveFileName);
            }

            K.userInfo.id = inputID.text;

            //SceneManager.LoadScene("Main");

            Title.Instance.ChangeScene("Main");
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

[Serializable]
public struct LoginInfo
{
    public string id;
    public string pw;
}

public class LoginLinker : MonoBehaviour
{
    public InputField inputID;
    public InputField inputPW;
    public Toggle toggleRemember;
    public Button btnLogin;

    private void Start()
    {
        btnLogin.onClick.AddListener(Login);

        inputID.text = "";
        inputPW.text = "";

        if (Json.HasFile("Remember"))
        {
            LoginInfo info = Json.Read<LoginInfo>("Remember");
            inputID.text = info.id;
            inputPW.text = info.pw;
        }
    }

    public void Login()
    {
        K.GetDB().SetListener(SERVER.CallbackType.LoginFail, () => 
        {
            print("Fail");
        }).SetListener(SERVER.CallbackType.LoginSuccess, () =>
        {
            if (toggleRemember.isOn)
            {
                Json.Write(new LoginInfo { id = inputID.text, pw = inputPW.text }, "Remember");
            }
            SceneManager.LoadScene("Main");
        }).Login(inputID.text, inputPW.text);
    }
}

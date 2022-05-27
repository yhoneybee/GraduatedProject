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
        K.GetDB().SetListener(SERVER.CallbackType.LoginFail, () =>
        {
            print("Fail");
        }).SetListener(SERVER.CallbackType.LoginSuccess, () =>
        {
            K.loginedId = inputID.text;
            if (toggleRemember.isOn)
            {
                Json.Write(new LoginInfo { id = inputID.text, pw = inputPW.text, remember = true }, saveFileName);
            }
            else
            {
                Json.Write(new LoginInfo { remember = false }, saveFileName);
            }
            SceneManager.LoadScene("Main");
        }).Login(inputID.text, inputPW.text);
    }
}

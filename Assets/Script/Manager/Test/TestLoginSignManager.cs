using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public struct SignPanel
{
    public GameObject parent;
    public TMP_InputField id;
    public TMP_InputField name;
    public TMP_InputField pw;
    public TMP_InputField confirmPw;
    public TextMeshProUGUI failText;
}

[Serializable]
public struct LoginPanel
{
    public TMP_InputField id;
    public TMP_InputField pw;
    public TextMeshProUGUI failText;
}

public class TestLoginSignManager : MonoBehaviour
{
    public SignPanel signPanel;
    public LoginPanel loginPanel;

    public void ResetText()
    {
        signPanel.failText.text = "";
        loginPanel.failText.text = "";
    }

    public void Sign()
    {
        if (CURDFactory.GetCURDable(out var curd))
        {
            if (curd.Sign(signPanel.id.text, signPanel.name.text, signPanel.pw.text, signPanel.confirmPw.text))
            {
                signPanel.failText.color = Color.green;
                signPanel.parent.SetActive(false);
            }
            else
            {
                signPanel.failText.color = Color.red;
                signPanel.failText.text = "회원가입에 실패했습니다";
            }
        }
    }

    public void Login()
    {
        if (CURDFactory.GetCURDable(out var curd))
        {
            curd.Login(loginPanel.id.text, loginPanel.pw.text);
        }
    }
}

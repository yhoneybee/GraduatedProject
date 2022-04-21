using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public struct SignPanel
{
    public GameObject goParent;
    public TMP_InputField inputId;
    public TMP_InputField inputName;
    public TMP_InputField inputPw;
    public TMP_InputField inputConfirmPw;
    public TextMeshProUGUI txtFailText;
}

[Serializable]
public struct LoginPanel
{
    public TMP_InputField inputId;
    public TMP_InputField inputPw;
    public TextMeshProUGUI txtFailText;
}

public class TestLoginSignManager : Singleton<TestLoginSignManager>
{
    public SignPanel signPanel;
    public LoginPanel loginPanel;

    public void ResetText()
    {
        signPanel.txtFailText.text = "";
        loginPanel.txtFailText.text = "";
    }

    public void Sign()
    {
        if (CURDGetter.GetCURDable(out var curd))
        {
            if (curd.Sign(signPanel.inputId.text, signPanel.inputName.text, signPanel.inputPw.text, signPanel.inputConfirmPw.text))
            {
                signPanel.txtFailText.color = Color.green;
                signPanel.goParent.SetActive(false);
            }
            else
            {
                signPanel.txtFailText.color = Color.red;
                signPanel.txtFailText.text = "회원가입에 실패했습니다";
            }
        }
    }

    public void Login()
    {
        if (CURDGetter.GetCURDable(out var curd))
        {
            curd.Login(loginPanel.inputId.text, loginPanel.inputPw.text);
        }
    }
}

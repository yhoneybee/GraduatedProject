using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignLinker : MonoBehaviour
{
    public Window window;
    public InputField inputID;
    public InputField inputPW;
    public InputField inputPWAgain;
    public Button btnSign;

    public void Start()
    {
        btnSign.onClick.AddListener(Sign);

        inputID.text = "";
        inputPW.text = "";
        inputPWAgain.text = "";
    }

    public void Sign()
    {
        K.GetDB().SetListener(SERVER.CallbackType.SignSuccess, () => 
        {
            window.Close();
        }).Sign(inputID.text, inputPW.text, inputPWAgain.text);
    }
}

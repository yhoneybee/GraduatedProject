using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyPacket;
using UnityEngine.EventSystems;

public class SignLinker : MonoBehaviour
{
    public InputField inputID;
    public InputField inputPw;
    public InputField inputPwAgain;
    public Button btnSign;
    public Button btnToLogin;

    private void OnEnable()
    {
        inputID.Select();
    }

    private void OnDisable()
    {
        inputID.text = string.Empty;
        inputPw.text = string.Empty;
        inputPwAgain.text = string.Empty;
    }

    public void Start()
    {
        btnSign.onClick.AddListener(Sign);

        inputID.text = "";
        inputPw.text = "";
        inputPwAgain.text = "";
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
            btnSign.onClick.Invoke();
        }
    }

    public void Sign()
    {
        REQ_Signin req = new REQ_Signin();
        req.id = inputID.text;
        req.pw = inputPw.text;
        req.pwAgain = inputPwAgain.text;

        K.Send(PacketType.REQ_SIGNIN_PACKET, req);

        Network.Instance.gamePackHandler.RES_Signin = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            if (!res.completed) return;

            gameObject.SetActive(false);
        };
    }
}

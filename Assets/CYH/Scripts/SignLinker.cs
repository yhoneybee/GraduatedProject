using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyPacket;

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
        REQ_Signin req = new REQ_Signin();
        req.id = inputID.text;
        req.pw = inputPW.text;
        req.pwAgain = inputPWAgain.text;

        Packet packet = new Packet();
        packet.SetData(PacketType.REQ_SIGNIN_PACKET, Data<REQ_Signin>.Serialize(req));

        Network.Instance.Send(packet);

        Network.Instance.gamePackHandler.RES_Signin = (packet) =>
        {
            var res = packet.GetPacket<RES>();
            print(res.reason);
            if (!res.completed) return;

            window.Close();
        };
    }
}

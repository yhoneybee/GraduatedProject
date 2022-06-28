using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot : MonoBehaviour
{
    public void Set(UserInfo userInfo)
    {
        txtPlayer.text = userInfo.id;
        txtInfo.text = txtInfo.text = $"Win : {userInfo.win:D5}\nLose : {userInfo.lose:D5}";
        txtReady.text = string.Empty;
    }

    public Text txtPlayer;
    public Text txtReady;
    public Text txtInfo;
}

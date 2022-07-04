using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLinker : MonoBehaviour
{
    public Button btnSamdae;
    public Button btnKanzi;
    public int playerNum;

    private void Start()
    {
        btnSamdae.onClick.AddListener(() =>
        {
            if (K.roomInfo.player1 == K.userInfo.id)
            {
                K.player1Type = CharactorType.Samdae;
                ButtonColorChange(K.player1Type);
            }
            else
            {
                K.player2Type = CharactorType.Samdae;
                ButtonColorChange(K.player2Type);
            }

            SelectCharactor();
        });

        btnKanzi.onClick.AddListener(() =>
        {
            if (K.roomInfo.player1 == K.userInfo.id)
            {
                K.player1Type = CharactorType.Kanzi;
                ButtonColorChange(K.player1Type);
            }
            else
            {
                K.player2Type = CharactorType.Kanzi;
                ButtonColorChange(K.player2Type);
            }

            SelectCharactor();
        });
    }

    private void Update()
    {
        btnKanzi.targetGraphic.raycastTarget = btnSamdae.targetGraphic.raycastTarget = playerNum == 0 && K.userInfo.id == K.roomInfo.player1;
        btnKanzi.targetGraphic.raycastTarget = btnSamdae.targetGraphic.raycastTarget = playerNum == 1 && K.userInfo.id == K.roomInfo.player2;
    }

    public void ButtonColorChange(CharactorType type)
    {
        switch (type)
        {
            case CharactorType.Samdae:
                btnSamdae.targetGraphic.color = btnKanzi.colors.normalColor;
                btnKanzi.targetGraphic.color = btnKanzi.colors.disabledColor;
                break;
            case CharactorType.Kanzi:
                btnSamdae.targetGraphic.color = btnKanzi.colors.disabledColor;
                btnKanzi.targetGraphic.color = btnKanzi.colors.normalColor;
                break;
        }
    }

    private static void SelectCharactor()
    {
        REQ_RES_Select req = new REQ_RES_Select();
        req.charactorType = K.roomInfo.player1 == K.userInfo.id ? K.player1Type : K.player2Type;
        //req.playerNum = K.player1.id == K.userInfo.id ? 0 : 1;

        K.Send(PacketType.REQ_SELECTCHARACTOR, req);
    }
}

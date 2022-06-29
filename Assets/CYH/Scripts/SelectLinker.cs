using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLinker : MonoBehaviour
{
    public Button btnSamdae;
    public Button btnKanzi;

    private void Start()
    {
        btnSamdae.onClick.AddListener(() => 
        {
            K.ownType = CharactorType.Samdae;
            ButtonColorChange(K.ownType);

            SelectCharactor();
        });

        btnKanzi.onClick.AddListener(() =>
        {
            K.ownType = CharactorType.Kanzi;
            ButtonColorChange(K.ownType);

            SelectCharactor();
        });
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
        req.charactorType = K.ownType;
        //req.playerNum = K.player1.id == K.userInfo.id ? 0 : 1;

        K.Send(PacketType.REQ_SELECTCHARACTOR, req);
    }
}

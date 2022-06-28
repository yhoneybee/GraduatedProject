using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title : SceneBase<Title> //≈∏¿Ã∆≤ æ¿ ≈¨∑°Ω∫
{
    public GameObject loginObj;

    public int Step; // æ¿ Ω∫≈‹
    public override void SceneAwake()
    {
        if(loginObj == null) loginObj = GameObject.Find("Login");
    }

    public override void SceneStart()
    {

    }
    public override void SceneEnter()
    {

    }

    public override void ScenePlaying()
    {
        switch (Step) 
        {
            case 0:

                if (Input.anyKeyDown)
                {
                    Step = 1;
                    loginObj.GetComponent<RectTransform>().DOAnchorPos(new Vector3(0,0,0), 1, false);
                    break;
                }

                break;
            case 1:



                break;
            case 2:
                break;
        }
    }

    public override void SceneEnd()
    {

    }
}

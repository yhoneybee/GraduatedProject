using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title : SceneBase<Title> //Ÿ��Ʋ �� Ŭ����
{
    public override void SceneAwake()
    {
    }

    public override void SceneStart()
    {
        SoundManager.Instance.PlayTitle();
    }
    public override void SceneEnter()
    {

    }

    public override void ScenePlaying()
    {

    }

    public override void SceneEnd()
    {

    }
}

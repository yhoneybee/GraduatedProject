using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : SceneBase<Main>
{
    public override void SceneAwake()
    {
        SoundManager.Instance.PlayMain();
    }

    public override void SceneStart()
    {

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

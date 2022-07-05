using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : SceneBase<Room>
{
    public override void SceneAwake()
    {
    }

    public override void SceneStart()
    {
        SoundManager.Instance.PlayRoom();
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

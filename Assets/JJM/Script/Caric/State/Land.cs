using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Land : State //����
{
    public override void Enter()
    {
        StateInit("Land", CARIC_STATE.FALL, CharactorState.IDLE);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}

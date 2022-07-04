using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Defense : State
{
    public override void Enter()
    {
        StateInit("Defense", CARIC_STATE.STAND, CharactorState.DEFENCE);
        ai.caric.isGuard = true;
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
        ai.caric.isGuard = false;
        ai.caric.rigid.velocity = Vector2.zero;
    }
}

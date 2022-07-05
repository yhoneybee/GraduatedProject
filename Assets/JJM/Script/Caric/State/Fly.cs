using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Fly : State
{
    public override void Enter()
    {
        StateInit("Fly", CARIC_STATE.HIT, CharactorState.FLY);
        ai.caric.isMoojuck = true;
    }
    public override void Tick()
    {
    }
    public override void Exit()
    {
        ai.caric.rigid.velocity = Vector2.zero;
        ai.caric.isMoojuck = false;
    }
}

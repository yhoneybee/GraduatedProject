using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Hit : State
{
    public override void Enter()
    {
        StateInit("Hit", CARIC_STATE.HIT, CharactorState.HIT);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
        ai.caric.rigid.velocity = Vector2.zero;
    }
}

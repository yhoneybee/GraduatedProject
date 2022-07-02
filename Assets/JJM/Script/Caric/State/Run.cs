using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Run : State
{
    float weight = 1.5f;
    public override void Enter()
    {
        StateInit("Run", CARIC_STATE.STAND, CharactorState.RUN);
        ai.caric.CreateDustMoveEffect();
        ai.caric.moveSpeed *= weight;
    }
    public override void Tick()
    {
        CaricMove();

        if(V.MoveKeyUp())
        {
            ai.ChangeState(gameObject.AddComponent<Idle>());
        } 
    }
    public override void Exit()
    {
        ai.caric.moveSpeed /= weight;
    }
}

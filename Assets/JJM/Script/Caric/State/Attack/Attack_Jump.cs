using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Attack_Jump : Attack
{
    public override void Enter()
    {
        StateInit("Attack_Jump", CARIC_STATE.ATTACK, CharactorState.ATTACK_JUMP);
        AttackInit(3f);
    }
    public override void Tick()
    {
        if (RayCastCheck()) ai.caric.rigid.velocity = new Vector2(0, ai.caric.rigid.velocity.y);
    }
    public override void Exit()
    {

    }
}

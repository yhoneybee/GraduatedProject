using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Jump : Attack
{
    public override void Enter()
    {
        StateInit("Attack_Jump", CARIC_STATE.ATTACK);
    }
    public override void Tick()
    {
        if (RayCastCheck()) ai.caric.rigid.velocity = new Vector2(0, ai.caric.rigid.velocity.y);
    }
    public override void Exit()
    {

    }
    public override void OnAttack(Caric other)
    {

    }
}

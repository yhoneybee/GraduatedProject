using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Crouch : Attack
{
    public override void Enter()
    {
        StateInit("Attack_Crouch", CARIC_STATE.ATTACK);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }

    public override void OnAttack(Caric other)
    {

    }
}

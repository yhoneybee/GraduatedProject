using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Weak : State
{
    public override void Enter()
    {
        StateInit("Attack_Weak", CARIC_STATE.ATTACK);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDae_Command_Weak : Attack
{
    public override void Enter()
    {
        StateInit("Command_Weak", CARIC_STATE.ATTACK);
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

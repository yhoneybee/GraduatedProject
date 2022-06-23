using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDae_Command_Weak : State
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
}

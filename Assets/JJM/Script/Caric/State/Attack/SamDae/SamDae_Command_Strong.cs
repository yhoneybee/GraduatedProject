using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDae_Command_Strong : State
{
    public override void Enter()
    {
        StateInit("Command_Strong", CARIC_STATE.ATTACK);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}

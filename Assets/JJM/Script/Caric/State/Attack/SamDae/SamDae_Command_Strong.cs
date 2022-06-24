using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDae_Command_Strong : State
{
    public override void Enter()
    {
        StateInit("Command_Strong", CARIC_STATE.ATTACK);
        //AddJumpingForce(ai.moveDir, ai.caric.jumpForce, 0.2f);
        ai.caric.jumpForce *= 1.5f;
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
        ai.caric.jumpForce /= 1.5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class SamDae_Command_Strong : Attack
{
    public override void Enter()
    {
        StateInit("Command_Strong", CARIC_STATE.ATTACK, CharactorState.ATTACK_COMMAND_STRONG);
        AttackInit(10f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Kanzi_Command_Weak : Attack
{
    public override void Enter()
    {
        StateInit("Command_Weak", CARIC_STATE.ATTACK, CharactorState.ATTACK_COMMAND_WEAK);
        AttackInit(0f);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
    }
}

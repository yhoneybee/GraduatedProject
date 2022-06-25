using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Attack_Crouch : Attack
{
    public override void Enter()
    {
        StateInit("Attack_Crouch", CARIC_STATE.ATTACK, CharactorState.ATTACK_CROUCH);
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

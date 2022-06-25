using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Attack_Weak : Attack
{
    public override void Enter()
    {
        StateInit("Attack_Weak", CARIC_STATE.ATTACK, CharactorState.ATTACK_WEAK);
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

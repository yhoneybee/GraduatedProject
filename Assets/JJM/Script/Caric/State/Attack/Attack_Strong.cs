using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Attack_Strong : Attack
{
    public override void Enter()
    {
        StateInit("Attack_Strong", CARIC_STATE.ATTACK, CharactorState.ATTACK_STRONG);
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

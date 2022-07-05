using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Kanzi_Command_Strong : Attack
{
    public override void Enter()
    {
        StateInit("Command_Strong", CARIC_STATE.ATTACK, CharactorState.ATTACK_COMMAND_STRONG);
        AttackInit(0f);

        ai.caric.isGuard = true;
        ai.caric.onHitEvent += Caric_onHitEvent;
    }

    public override void Tick()
    {

    }
    public override void Exit()
    {
        ai.caric.onHitEvent -= Caric_onHitEvent;
        ai.caric.isGuard = false;
    }

    private void Caric_onHitEvent(object sender, System.EventArgs e)
    {
        Debug.Log("Change AttackStrong!!!!");
        ai.ChangeState(gameObject.AddComponent<Attack_Strong>());
    }
}

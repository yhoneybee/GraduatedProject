using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Crouch_Hit : State
{
    public override void Enter()
    {
        StateInit("Crouch_Hit", CARIC_STATE.HIT, CharactorState.CROUCH_HIT);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}

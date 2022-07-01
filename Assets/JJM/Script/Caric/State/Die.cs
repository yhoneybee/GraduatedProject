using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Die : State
{
    public override void Enter()
    {
        StateInit("Die", CARIC_STATE.DIE, CharactorState.DIE);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
    }
}

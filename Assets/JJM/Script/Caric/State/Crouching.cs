using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Crouching : State
{
    public override void Enter()
    {
        StateInit("Crouching", CARIC_STATE.CROUCH, CharactorState.CROUCHING);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}

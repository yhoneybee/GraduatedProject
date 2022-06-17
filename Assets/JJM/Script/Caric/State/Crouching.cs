using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : State
{
    public override void Enter()
    {
        StateInit("Crouching", CARIC_STATE.CROUCH);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}

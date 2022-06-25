using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : State
{
    public override void Enter()
    {
        StateInit("Hit", CARIC_STATE.HIT);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}

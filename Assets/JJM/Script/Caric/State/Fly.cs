using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : State
{
    public override void Enter()
    {
        StateInit("Fly", CARIC_STATE.HIT);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
}

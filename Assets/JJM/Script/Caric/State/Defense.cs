using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : State
{
    public override void Enter()
    {
        StateInit("Defense", CARIC_STATE.STAND);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
        
    }
}
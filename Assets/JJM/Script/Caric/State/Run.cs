using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State
{
    float weight = 1.5f;
    public override void Enter()
    {
        StateInit("Run");
        caric.moveSpeed *= weight;
    }
    public override void Tick()
    {
        CaricMove();

        if(V.MoveKeyUp())
        {
            ai.ChangeState(gameObject.AddComponent<Idle>());
        } 
    }
    public override void Exit()
    {
        caric.moveSpeed /= weight;
    }
}

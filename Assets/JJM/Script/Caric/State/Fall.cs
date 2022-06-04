using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : State
{

    public override void Enter()
    {
        StateInit("Fall", CARIC_STATE.FLY);
    }

    public override void Tick()
    {
        if(ai.caric.rigid.velocity.y == 0) ai.ChangeState(gameObject.AddComponent<Idle>());

        Debug.Log("FALL !!");
    }

    public override void Exit()
    {
    }
}

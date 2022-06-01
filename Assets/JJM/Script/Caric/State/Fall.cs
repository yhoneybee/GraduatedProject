using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : State
{
    public override void Enter()
    {
        StateInit("Idle");
    }

    public override void Update()
    {
        //CaricMove();

        if(caric.rigid.velocity.y == 0) ai.ChangeState(gameObject.AddComponent<Idle>());

        Debug.Log("FALL !!");
    }

    public override void Exit()
    {
    }
}

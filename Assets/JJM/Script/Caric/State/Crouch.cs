using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : State
{
    public override void Enter()
    {
        StateInit("Crouch");
    }
    public override void Tick()
    {
        if(V.GetKeyUp(V.CROUCH_KEY))
        {
            ai.ChangeState(gameObject.AddComponent<Idle>());
        }
    }
    public override void Exit()
    {
        
    }
}

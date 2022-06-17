using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    public override void Enter()
    {
        StateInit("Walk", CARIC_STATE.STAND);
        ai.caric.sprite.flipX = (ai.moveDir == -1);
    }
    public override void Tick()
    {
        CaricMove();

        // if(caric.moveDir == 0 || V.MoveKeyUp())
        // {
        //     ai.ChangeState(gameObject.AddComponent<Idle>());
        // } 
        // else if(V.GetKeyDown(V.JUMP_KEY)) ai.ChangeState(gameObject.AddComponent<Jump>());

        Debug.Log("Walk !!");  
    }
    public override void Exit()
    {
        
    }
}

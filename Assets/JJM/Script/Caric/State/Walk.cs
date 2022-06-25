using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Walk : State
{
    public override void Enter()
    {
        StateInit("Walk", CARIC_STATE.STAND, CharactorState.WALK);
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

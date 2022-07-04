using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Jump : State
{
    public override void Enter()
    {
        StateInit("Jump", CARIC_STATE.JUMP, CharactorState.JUMP); 
        ai.caric.currenState = CARIC_STATE.JUMP;

        ai.caric.rigid.velocity = Vector2.zero;
    }
    public override void Tick()
    {
        if (RayCastCheck()) ai.caric.rigid.velocity = new Vector2(0, ai.caric.rigid.velocity.y);

        if (ai.caric.rigid.velocity.y <= 0) ai.ChangeState(gameObject.AddComponent<Fall>());

        Debug.Log("JUMP !!");  
    }
    public override void Exit()
    {
        
    }
}

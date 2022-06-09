using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    public override void Enter()
    {
        StateInit("Jump", CARIC_STATE.FLY);
        ai.caric.rigid.AddForce(Vector2.up * ai.caric.jumpForce, ForceMode2D.Impulse);
        ai.caric.rigid.AddForce(Vector2.right * ai.caric.moveDir * (ai.caric.moveSpeed * 5), ForceMode2D.Force);
    }
    public override void Tick()
    {
        if(ai.caric.rigid.velocity.y <= 0) ai.ChangeState(gameObject.AddComponent<Fall>());
        
        Debug.Log("JUMP !!");  
    }
    public override void Exit()
    {
        
    }
}

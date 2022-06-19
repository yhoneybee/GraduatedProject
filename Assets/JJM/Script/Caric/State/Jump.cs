using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    public override void Enter()
    {
        StateInit("Jump", CARIC_STATE.JUMP);
        ai.caric.rigid.AddForce(Vector2.one * new Vector2(ai.moveDir * (ai.caric.moveSpeed), ai.caric.jumpForce), ForceMode2D.Impulse);
        //ai.caric.jumpForce = 100f;
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

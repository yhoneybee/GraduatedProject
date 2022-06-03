using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    public override void Enter()
    {
        StateInit("Jump");
        caric.rigid.AddForce(Vector2.up * caric.jumpForce, ForceMode2D.Impulse);
        caric.rigid.AddForce(Vector2.right * caric.moveDir * (caric.moveSpeed * 5), ForceMode2D.Force);
    }
    public override void Tick()
    {
        if(caric.rigid.velocity.y <= 0) ai.ChangeState(gameObject.AddComponent<Fall>());
        
        Debug.Log("JUMP !!");  
    }
    public override void Exit()
    {
        
    }
}

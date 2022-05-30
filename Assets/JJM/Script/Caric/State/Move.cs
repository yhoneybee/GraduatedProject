using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    float h;
    public override void Enter()
    {
        GetInfo();
        caric.anim.Play("Run");
    }
    public override void Update()
    {
        h = V.GetAxisRaw("Horizontal");

        Debug.Log("MOVE !!");  

        if(h == 0) ai.ChangeState(gameObject.AddComponent<Idle>());
    }
    public override void Exit()
    {
        
    }
}

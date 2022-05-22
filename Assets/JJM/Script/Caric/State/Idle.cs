using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State //대기 상태
{
    float h; // 수평 값
    public override void Enter()
    {
        GetInfo();
        caric.anim.Play("Idle");
    }
    public override void Update()
    {
        h = V.GetAxisRaw("Horizontal");

        Debug.Log("IDLE !!");

        if(h != 0) ai.ChangeState(gameObject.AddComponent<Move>());
    }
    public override void Exit()
    {
        
    }
}

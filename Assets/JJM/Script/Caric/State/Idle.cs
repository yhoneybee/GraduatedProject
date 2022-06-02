using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State //대기 상태
{
    private List<SpriteRenderer> sprites;
    public override void Enter()
    {
        StateInit("Idle");
        sprites = V.Find_Child_Component_List<SpriteRenderer>(gameObject);
    }
    public override void Update()
    {
        Debug.Log("IDLE !!");

        if(caric.moveDir != 0)
        {
            caric.sprite.flipX = (caric.moveDir == -1);
            ai.ChangeState(gameObject.AddComponent<Walk>());
        }
        if(V.GetKeyDown(V.JUMP_KEY)) //점프
        {
            ai.ChangeState(gameObject.AddComponent<Jump>());
        }   
        else if(V.GetKeyDown(V.CROUCH_KEY)) //앉기
        {
            ai.ChangeState(gameObject.AddComponent<Crouch>());
        }
    }
    public override void Exit()
    {
        
    }
}

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
            foreach(var sp in sprites) //스프라이트 플립
            {
                sp.flipX = (caric.moveDir == 1);
            }    
            ai.ChangeState(gameObject.AddComponent<Move>());
        }
        if(V.GetKeyDown(KeyCode.W)) //점프
            ai.ChangeState(gameObject.AddComponent<Jump>());
    }
    public override void Exit()
    {
        
    }
}

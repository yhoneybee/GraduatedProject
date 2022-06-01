using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MOVEDIR
{
    STAND = 0,
    LEFT = -1,
    RIGHT = 1,
}

public class Move : State
{
    public override void Enter()
    {
        StateInit("Run");
    }
    public override void Update()
    {
        CaricMove();
        
        if(caric.moveDir == 0 || V.MoveKeyUp()) ai.ChangeState(gameObject.AddComponent<Idle>());
        else if(V.GetKeyDown(KeyCode.W)) ai.ChangeState(gameObject.AddComponent<Jump>());

        Debug.Log("MOVE !!");  
    }
    public override void Exit()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : State
{

    float delayTime = 0;
    public override void Enter()
    {
        StateInit("", CARIC_STATE.STAND); //애니메이션 안함
        delayTime = V.worldTime + 0.25f;
    }
    public override void Tick()
    {
        if(delayTime < V.worldTime)
        {
            ai.ChangeState(gameObject.AddComponent<Walk>());
        }
        else
        {
            if(V.MoveKeyDown()) // 달리기 전환
            {
                ai.ChangeState(gameObject.AddComponent<Run>());
            }
        }
    }
    public override void Exit()
    {
        
    }
}

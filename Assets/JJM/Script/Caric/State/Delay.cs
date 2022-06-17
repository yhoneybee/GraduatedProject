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
        
    }
    public override void Exit()
    {
        
    }
}

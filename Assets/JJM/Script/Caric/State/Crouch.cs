using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Crouch : State
{
    public override void Enter()
    {
        StateInit("Crouch", CARIC_STATE.CROUCH, CharactorState.CROUCH);
        ai.caric.currenState = CARIC_STATE.CROUCH;
    }
    
    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        
    }
}

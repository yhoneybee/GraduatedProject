using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Idle : State //λκΈ° μν
{
    public override void Enter()
    {
        StateInit("Idle", CARIC_STATE.STAND, CharactorState.IDLE);
        ai.caric.currenState = CARIC_STATE.STAND;
    }
    public override void Tick()
    {
        Debug.Log("IDLE !!");
    }
    public override void Exit()
    {
        
    }
}

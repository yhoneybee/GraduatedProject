using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Idle : State //대기 상태
{
    public override void Enter()
    {
        StateInit("Idle", CARIC_STATE.STAND, CharactorState.IDLE);
    }
    public override void Tick()
    {
        Debug.Log("IDLE !!");
    }
    public override void Exit()
    {
        
    }
}

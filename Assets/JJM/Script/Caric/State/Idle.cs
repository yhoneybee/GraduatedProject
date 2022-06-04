using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State //대기 상태
{
    private List<SpriteRenderer> sprites;
    public override void Enter()
    {
        StateInit("Idle", CARIC_STATE.STAND);
    }
    public override void Tick()
    {
        Debug.Log("IDLE !!");
    }
    public override void Exit()
    {
        
    }
}

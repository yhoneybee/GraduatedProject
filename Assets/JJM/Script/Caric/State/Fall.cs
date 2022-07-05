using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Fall : State
{
    bool IsGround;
    public override void Enter()
    {
        StateInit("Fall", CARIC_STATE.FALL, CharactorState.FALL);
        IsGround = false;
    }

    public override void Tick()
    {
        //if (RayCastCheck()) ai.caric.rigid.velocity = new Vector2(0, ai.caric.rigid.velocity.y);

        if (IsGround || ai.caric.rigid.velocity.y == 0) ai.ChangeState(gameObject.AddComponent<Idle>());

        Debug.Log("FALL !!");
    }

    public override void Exit()
    {
        ai.IsKeySafe = true;
        ai.caric.rigid.velocity = Vector2.zero;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGround = true;
        }
    }

}

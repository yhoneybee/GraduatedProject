using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : State
{
    bool IsGround;
    public override void Enter()
    {
        StateInit("Fall", CARIC_STATE.FLY);
        IsGround = false;
    }

    public override void Tick()
    {
        //ai.caric.rigid.velocity.y == 0 || 
        if (IsGround)
        {
            ai.ChangeState(gameObject.AddComponent<Idle>());
            IsGround = false;
        }

        Debug.Log("FALL !!");
    }

    public override void Exit()
    {
        ai.caric.rigid.velocity = Vector2.zero;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Effect.Instance.GetEffect("Dust_Jump", ai.caric.bone.foot.transform.position);
            IsGround = true;
        }
    }

}

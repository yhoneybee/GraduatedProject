using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public abstract class Attack : State
{
    private float hitBackValue = 0;

    public void AttackInit(float hitbackvalue) 
    {
        hitBackValue = hitbackvalue;
    }
    public void OnAttack(Caric other) 
    {
        Vector2 dir = (transform.position.x - other.transform.position.x < 0) ? new Vector2(-1, 0) : new Vector2(1, 0); //방향 구하기
        other.FlipSprite(dir.x);

        other.rigid.AddForce(-dir * hitBackValue, ForceMode2D.Impulse);
    }
    
}

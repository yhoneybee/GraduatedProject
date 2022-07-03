using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public abstract class Attack : State
{
    protected Vector2 relativeDir; //������� ����
    protected float hitBackValue = 0;

    public void AttackInit(float hitbackvalue) 
    {
        hitBackValue = hitbackvalue;
        ai.caric.attackBox.onHit = false;
    }
    public virtual void OnAttack(Caric other) 
    {
        relativeDir = (transform.position.x - other.transform.position.x < 0) ? new Vector2(-1, 0) : new Vector2(1, 0); //���� ���ϱ�
        other.FlipSprite(relativeDir.x);

        other.rigid.AddForce(-relativeDir * hitBackValue, ForceMode2D.Impulse);
    }
    
}

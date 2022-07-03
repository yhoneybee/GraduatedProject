using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class SamDae_Command_Weak : Attack
{
    public override void Enter()
    {
        StateInit("Command_Weak", CARIC_STATE.ATTACK, CharactorState.ATTACK_COMMAND_WEAK);
        AttackInit(-8f);
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {

    }

    public override void OnAttack(Caric other)
    {
        float distance = Vector2.Distance(gameObject.transform.position, other.transform.position);
        if (distance <= 2f) AttackInit(0f);

        base.OnAttack(other);
        //StartCoroutine(AttackBring(other, 20f));
    }

    //IEnumerator AttackBring(Caric other, float power) 
    //{
    //    float pos_x = transform.position.x;
    //    float other_pos_x = other.transform.position.x;

    //    while(Mathf.Abs(pos_x - other_pos_x) > 1f) 
    //    {
    //        other.transform.Translate(relativeDir * power * Time.deltaTime);
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
}

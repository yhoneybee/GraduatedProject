using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Copy : State //복사 드가자~
{
    public override void Enter()
    {

    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
        
    }
}

[System.Serializable]
public abstract class State : MonoBehaviour //상태 베이스
{
    protected CaricAI ai;
    protected Caric caric;
    public abstract void Enter();
    public abstract void Tick();
    public abstract void Exit();
    public void CaricMove() => transform.Translate(Vector3.right * caric.moveDir * caric.moveSpeed * Time.deltaTime);

    public void StateInit(string playeAnim) //플레이어 정보 받아오기
    {
        ai = GetComponent<CaricAI>();
        caric = GetComponent<Caric>();

        if(playeAnim != "") 
        caric.anim.Play(playeAnim); //해당 애니메이션 실행
    }

}

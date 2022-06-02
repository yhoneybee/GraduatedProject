using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State : MonoBehaviour //상태 베이스
{
    protected CaricAI ai;
    protected Caric caric; 
    
    public void StateInit(string playeAnim) //플레이어 정보 받아오기
    {
        ai = GetComponent<CaricAI>();
        caric = GetComponent<Caric>();

        caric.anim.Play(playeAnim); //해당 애니메이션 실행
    }

    public void CaricMove() => transform.Translate(Vector3.right * caric.moveDir * caric.moveSpeed * Time.deltaTime);
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

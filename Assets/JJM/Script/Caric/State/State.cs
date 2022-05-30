using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State : MonoBehaviour //상태 베이스
{
    protected CaricAI ai;
    protected Caric caric;

    public void GetInfo() //플레이어 정보 받아오기
    {
        ai = GetComponent<CaricAI>();
        caric = GetComponent<Caric>();
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

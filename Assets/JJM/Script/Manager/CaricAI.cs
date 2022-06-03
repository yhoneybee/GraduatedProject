using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CARIC_STATE
{
    IDEL,
    CROUCH, // s
    WALK, // a,d
    RUN, // aa,dd
    JUMP, // w
    FALL, 
    ATTACK, // j, k, command
    DEFENCE, // l
    HIT,
    FLY,
    DIE,
}

public class CaricAI : MonoBehaviour //캐릭터 상태 관리 클래스
{
    public State state;
    // Start is called before the first frame update
    void Start()
    {   
        if(state == null) ChangeState(gameObject.AddComponent<Idle>());
    }   

    // Update is called once per frame
    void Update()
    {
        if(state != null) state.Tick();
    }

    public void ChangeState(State newState) //상태 변경
    {
        if(state != null)
        {
            state.Exit(); //현재 상태 종료
            Destroy(state);
        } 
        
        state = newState;
        state.Enter(); //새로운 상태 시작
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;
public enum CARIC_STATE
{
    STAND,
    FLY,
    CROUCH,
    ATTACK,
}

public class CaricAI : MonoBehaviour //캐릭터 상태 관리 클래스
{
    public State state;
    public Caric caric;
    public Caric_Command caric_Command;
    public CARIC_STATE cs = CARIC_STATE.STAND;
    private float delayTime;
    private float backupDir;
    // Start is called before the first frame update
    void Start()
    {   
        if(caric == null) caric = GetComponent<Caric>();
        if (caric_Command == null) caric_Command = GetComponent<Caric_Command>();
        if (state == null) ChangeState(gameObject.AddComponent<Idle>());
    }   

    // Update is called once per frame
    void Update()
    {

        switch(cs)
        {
            case CARIC_STATE.STAND: //서 있는 상태
                
                if(V.MoveKeyDown())
                {
                    if(caric.moveDir == 0)
                    {
                        ChangeState(gameObject.AddComponent<Idle>());
                    } 
                    else 
                    {
                        CaricMove();
                    }
                }
                else if(V.MoveKeyUp())
                {
                    ChangeState(gameObject.AddComponent<Idle>());
                }
                else if(V.GetKeyDown(V.JUMP_KEY)) //점프
                {
                    ChangeState(gameObject.AddComponent<Jump>());
                }
                else if(V.GetKeyDown(V.CROUCH_KEY)) //앉기
                {
                    ChangeState(gameObject.AddComponent<Crouch>());
                }
                else if (V.GetKeyDown(V.ATTACK_WEAK_KEY)) 
                {
                    caric_Command.CheckCommad("J");
                    ChangeState(caric.Attack_Weak);
                }
                else if (V.GetKeyDown(V.ATTACK_STRONG_KEY))
                {
                    caric_Command.CheckCommad("K");
                    ChangeState(caric.Attack_Strong);
                }
                else if(V.GetKeyDown(V.DEFENSE_KEY)) //방어
                {
                    ChangeState(gameObject.AddComponent<Defense>());
                }
                else if(V.GetKeyUp(V.DEFENSE_KEY)) 
                {
                    ChangeState(gameObject.AddComponent<Idle>());
                }


                break;
            case CARIC_STATE.FLY: //공중
                break;
            case CARIC_STATE.CROUCH: //앉은 상태

                if(V.GetKeyUp(V.CROUCH_KEY))
                {
                    ChangeState(gameObject.AddComponent<Idle>());
                }

                break;
            case CARIC_STATE.ATTACK:
                break;
            
        }

        
    }
    private void FixedUpdate()
    {
        if (state != null) state.Tick(); 
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

    public void ChangeStateString(string newState) 
    {
        switch (newState) 
        {
            case "Idle":
                ChangeState(gameObject.AddComponent<Idle>());
                break;
            case "Fall":
                ChangeState(gameObject.AddComponent<Fall>());
                break;
        }
    }
    
    public void CaricMove()
    {
        if(delayTime < V.worldTime)
        {
            ChangeState(gameObject.AddComponent<Walk>());
            backupDir = caric.moveDir;
            delayTime = V.worldTime + 0.25f;
        } 
        else
        {
            if(backupDir != caric.moveDir) return; //방향 전환 달리기 제어

            ChangeState(gameObject.AddComponent<Run>());
        }

        
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;
public enum CARIC_STATE
{
    STAND,
    JUMP,
    FALL,
    CROUCH,
    ATTACK,
}

public enum ATTACK_STATE 
{
    ATTACK_WEAK,
    ATTACK_STRONG,
    ATTACK_CROUCH,
    ATTACK_JUMP,
    ATTACK_COMMAND_WEAK,
    ATTACK_COMMAND_STRONG,
}

public class CaricAI : MonoBehaviour //캐릭터 상태 관리 클래스
{
    public State state;
    public Caric caric;
    public Caric_Command caric_Command;
    public CARIC_STATE cs = CARIC_STATE.STAND;
    private float delayTime;
    private float backupDir;
    public float moveDir; //수평 값
    // Start is called before the first frame update
    void Start()
    {
        if (caric == null) caric = GetComponent<Caric>();
        if (caric_Command == null) caric_Command = GetComponent<Caric_Command>();
        if (state == null) ChangeState(gameObject.AddComponent<Idle>());

        Network.Instance.gamePackHandler.RES_Charactor = EnemyAI;
    }   

    // Update is called once per frame
    void Update()
    {
        switch (LayerMask.LayerToName(gameObject.layer)) 
        {
            case "Player":
                PlayerAI();
                break;
        }

    }
 
    private void FixedUpdate()
    {
        if (state != null) state.Tick(); 
    }

    public void PlayerAI() 
    {
        moveDir = V.GetAxisRaw("Horizontal");

        switch (cs)
        {
            case CARIC_STATE.STAND: //서 있는 상태

                if (V.MoveKeyDown())
                {
                    if (moveDir == 0)
                    {
                        ChangeState(gameObject.AddComponent<Idle>());
                    }
                    else
                    {
                        CaricMove();
                    }
                }
                else if (V.MoveKeyUp())
                {
                    ChangeState(gameObject.AddComponent<Idle>());
                }
                else if (V.GetKeyDown(V.JUMP_KEY)) //점프
                {
                    ChangeState(gameObject.AddComponent<Jump>());
                }
                else if (V.GetKeyDown(V.CROUCH_KEY)) //앉기
                {
                    ChangeState(gameObject.AddComponent<Crouching>());
                }
                else if (V.GetKeyDown(V.ATTACK_WEAK_KEY))
                {
                    caric_Command.CheckCommad("J");
                    ChangeState(caric.attackState);
                }
                else if (V.GetKeyDown(V.ATTACK_STRONG_KEY))
                {
                    caric_Command.CheckCommad("K");
                    ChangeState(caric.attackState);
                }
                else if (V.GetKeyDown(V.DEFENSE_KEY)) //방어
                {
                    ChangeState(gameObject.AddComponent<Defense>());
                }
                else if (V.GetKeyUp(V.DEFENSE_KEY))
                {
                    ChangeState(gameObject.AddComponent<Idle>());
                }


                break;
            case CARIC_STATE.JUMP: //공중

                if (V.GetKeyDown(V.ATTACK_WEAK_KEY) || V.GetKeyDown(V.ATTACK_STRONG_KEY))
                {
                    caric_Command.CheckCommad("J↑");
                    ChangeState(caric.attackState);
                }

                break;
            case CARIC_STATE.FALL: //공중

                break;
            case CARIC_STATE.CROUCH: //앉은 상태

                if (!V.GetKey(V.CROUCH_KEY))
                {
                    ChangeState(gameObject.AddComponent<Idle>());
                }
                else if (V.GetKeyDown(V.ATTACK_WEAK_KEY) || V.GetKeyDown(V.ATTACK_STRONG_KEY))
                {
                    caric_Command.CheckCommad("J↓");
                    ChangeState(caric.attackState);
                }

                break;
            case CARIC_STATE.ATTACK:

                if (AttackStateCheck())
                {
                    ChangeState(gameObject.AddComponent<Idle>());
                    return;
                }

                break;

        }
    }

    public void EnemyAI(Packet packet)
    {
        var obj = packet.GetPacket<REQ_RES_Charactor>();

        moveDir = obj.dir;
        gameObject.transform.position = new Vector2(obj.posX, obj.posY);
        
        CharactorState cs = obj.charactorState;

        switch (cs) 
        {
            case CharactorState.IDLE:
                ChangeState(gameObject.AddComponent<Idle>());
                break;
            case CharactorState.WALK:
                ChangeState(gameObject.AddComponent<Walk>());
                break;
        }
    }


    public void ChangeState(State newState) //상태 변경
    {
        //Debug.Log("스테이트 변경");

        if(state != null)
        {
            state.Exit(); //현재 상태 종료
            Destroy(state);
        } 
        
        state = newState;
        state.Enter(); //새로운 상태 시작

        SendPacket(state);
        //Debug.Log("Class Name :" + state.GetType().Name);
    }
    
    public void SendPacket(State currentState) 
    {
        if (LayerMask.LayerToName(gameObject.layer) != "Player") return;

        REQ_RES_Charactor req = new REQ_RES_Charactor();
        req.dir = moveDir;
        req.posX = gameObject.transform.position.x;
        req.posY = gameObject.transform.position.y;

        switch (currentState.GetType().Name) 
        {
            case "Idle":
                req.charactorState = CharactorState.IDLE;
                break;
            case "Walk":
                req.charactorState = CharactorState.WALK;
                break;
        }

        K.Update(req);
    }

    public void CaricMove()
    {
        if(delayTime < V.worldTime)
        {
            ChangeState(gameObject.AddComponent<Walk>());
            backupDir = moveDir;
            delayTime = V.worldTime + 0.25f;
        } 
        else
        {
            if(backupDir != moveDir) return; //방향 전환 달리기 제어

            ChangeState(gameObject.AddComponent<Run>());
        }
    }

    public bool AttackStateCheck() 
    {
        var currentAnim = caric.anim.GetCurrentAnimatorStateInfo(0);

        return currentAnim.IsName("Idle") || currentAnim.IsName("Fall");
    }
  
}

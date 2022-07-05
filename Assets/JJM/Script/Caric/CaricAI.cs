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
    HIT,
    DIE,
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
    public CharactorState charactorState = CharactorState.IDLE;
    private float delayTime;
    private float backupDir;
    public float moveDir; //수평 값
    public bool IsKeySafe = false;
    // Start is called before the first frame update
    void Start()
    {
        if (caric == null) caric = GetComponent<Caric>();
        if (caric_Command == null) caric_Command = GetComponent<Caric_Command>();
        if (state == null) ChangeState(gameObject.AddComponent<Idle>());


        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Network.Instance.gamePackHandler.RES_Charactor = EnemyAI;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAI();
    }

    private void FixedUpdate()
    {
        if (state != null)
        {
            state.Tick();
            SendPacket(state);
        }
    }

    public void PlayerAI()
    {
        if (gameObject.layer != LayerMask.NameToLayer("Player")) return;

        moveDir = V.GetAxisRaw("Horizontal");
        caric.dir = moveDir;

        switch (cs)
        {
            case CARIC_STATE.STAND: //서 있는 상태

                if (V.MoveKeyDown(ref IsKeySafe))
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

                Attack2OtherState();

                break;
            case CARIC_STATE.HIT:
                break;

        }
    }

    public void EnemyAI(Packet packet)
    {

        var obj = packet.GetPacket<REQ_RES_Charactor>();

        caric.Hp = obj.hp;
        moveDir = obj.dir;
        gameObject.transform.position = new Vector2(obj.posX, gameObject.transform.position.y);

        CharactorState cs = obj.charactorState;
        
        if(charactorState != obj.charactorState)
        {
            switch (cs)
            {
                case CharactorState.IDLE:
                    ChangeState(gameObject.AddComponent<Idle>());
                    break;
                case CharactorState.WALK:
                    caric.FlipSprite(moveDir);
                    ChangeState(gameObject.AddComponent<Walk>());
                    break;
                case CharactorState.RUN:
                    caric.FlipSprite(moveDir);
                    ChangeState(gameObject.AddComponent<Run>());
                    break;
                case CharactorState.JUMP:
                    ChangeState(gameObject.AddComponent<Jump>());
                    break;
                case CharactorState.FALL:
                    break;
                case CharactorState.CROUCH:
                    ChangeState(gameObject.AddComponent<Crouch>());
                    break;
                case CharactorState.CROUCHING:
                    ChangeState(gameObject.AddComponent<Crouching>());
                    break;
                case CharactorState.DEFENCE:
                    ChangeState(gameObject.AddComponent<Defense>());
                    break;
                case CharactorState.ATTACK_WEAK:
                    ChangeState(caric.SetCommandState(ATTACK_STATE.ATTACK_WEAK));
                    break;
                case CharactorState.ATTACK_STRONG:
                    ChangeState(caric.SetCommandState(ATTACK_STATE.ATTACK_STRONG));
                    break;
                case CharactorState.ATTACK_CROUCH:
                    ChangeState(caric.SetCommandState(ATTACK_STATE.ATTACK_CROUCH));
                    break;
                case CharactorState.ATTACK_JUMP:
                    ChangeState(caric.SetCommandState(ATTACK_STATE.ATTACK_JUMP));
                    break;
                case CharactorState.ATTACK_COMMAND_WEAK:
                    ChangeState(caric.SetCommandState(ATTACK_STATE.ATTACK_COMMAND_WEAK));
                    break;
                case CharactorState.ATTACK_COMMAND_STRONG:
                    ChangeState(caric.SetCommandState(ATTACK_STATE.ATTACK_COMMAND_STRONG));
                    break;
                case CharactorState.HIT:
                    ChangeState(gameObject.AddComponent<Hit>());
                    break;
                case CharactorState.CROUCH_HIT:
                    ChangeState(gameObject.AddComponent<Hit>());
                    break;
                case CharactorState.FLY:
                    ChangeState(gameObject.AddComponent<Fly>());
                    break;
                case CharactorState.DIE:
                    ChangeState(gameObject.AddComponent<Die>());
                    break;

            }
        }
    }


    public void ChangeState(State newState) //상태 변경
    {
        //Debug.Log("스테이트 변경");

        if (state != null)
        {
            state.Exit(); //현재 상태 종료
            Destroy(state);
        }

        state = newState;
        state.Enter(); //새로운 상태 시작
        //Debug.Log("Class Name :" + state.GetType().Name);
    }

    public void SendPacket(State currentState)
    {
        if (LayerMask.LayerToName(gameObject.layer) != "Player") return;

        REQ_RES_Charactor req = new REQ_RES_Charactor();

        req.dir = moveDir;
        req.posX = gameObject.transform.position.x;
        req.hp = caric.Hp;
        req.charactorState = charactorState;
        
        K.PositionUpdate(req);
    }

    public void Attack2OtherState()
    {
        var animPlayTime = caric.anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (animPlayTime >= 1f)
        {
            switch (caric.currenState)
            {
                case CARIC_STATE.STAND:
                    Debug.Log("STAND");
                    ChangeState(gameObject.AddComponent<Idle>());
                    break;
                case CARIC_STATE.JUMP:
                    Debug.Log("JUMP");
                    ChangeState(gameObject.AddComponent<Fall>());
                    break;
                case CARIC_STATE.CROUCH:
                    Debug.Log("CROUCH");
                    ChangeState(gameObject.AddComponent<Crouch>());
                    break;
            }
        }
    }
    public void CaricMove()
    {
        caric.FlipSprite(moveDir);

        if (delayTime < V.worldTime)
        {
            ChangeState(gameObject.AddComponent<Walk>());
            backupDir = moveDir;
            delayTime = V.worldTime + V.COMMAND_DELAY_TIME;
        }
        else
        {
            if (backupDir != moveDir) return; //방향 전환 달리기 제어

            ChangeState(gameObject.AddComponent<Run>());
        }
    }

}

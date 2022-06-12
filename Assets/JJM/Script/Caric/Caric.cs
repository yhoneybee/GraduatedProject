using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric : MonoBehaviour
{
    [Header("=====Base Caric Class=====")]
    public float moveSpeed;
    public float jumpForce;

    [Header("AttackCommands")]
    public State Attack_Weak;
    public State Attack_Strong;

    [Header("Components")]
    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rigid;

    [Header("Class")]
    public Caric_Command caric_Command;

    public virtual void Start()
    {
        C_Init();
    }

    public void C_Init() //캐릭터 초기화
    {
        Caric_Setting();
        Caric_GetComponent();
    }

    public void Caric_Setting() //캐릭터 기본 값 셋팅
    {
        moveSpeed = 5;
        jumpForce = 6;
    }

    public void Caric_GetComponent() // 컴포넌트 get
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void SetAttackState(string attackName, State newState) //공격 종류 설정
    {  
       switch(attackName)
       {
            case "Weak":
                Attack_Weak = newState;
                break;
            case "Strong":
                Attack_Strong = newState;
                break;
       }
    }

    
}

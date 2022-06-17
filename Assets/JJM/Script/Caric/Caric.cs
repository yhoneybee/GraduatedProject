using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric : MonoBehaviour
{
    [Header("=====Base Caric Class=====")]
    public float moveSpeed;
    public float jumpForce;

    [Header("AttackCommands")]
    public State attackState;

    [Header("Components")]
    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rigid;

    [Header("Class")]
    public Bone bone;

    public virtual void Start()
    {
        C_Init();
    }

    public void C_Init() //캐릭터 초기화
    {
        Caric_Setting();
        Caric_GetComponent();
        Caric_GetClass();
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

    public void Caric_GetClass() //클래스 get
    {
        bone = GetComponentInChildren<Bone>();
    }

    public void SetAttackState(State newState) //공격 종류 설정
    {
        attackState = newState;
    }

    
}

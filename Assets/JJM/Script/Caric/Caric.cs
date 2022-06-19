using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Caric : MonoBehaviour
{
    [Header("=====Base Caric Class=====")]
    public string caricName;
    public int caricNumber;
    public float moveSpeed;
    public float jumpForce;

    [Header("AttackCommands")]
    public State attackState;
    public State commandWeakState;
    public State commandStrongState;

    [Header("Components")]
    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rigid;

    [Header("Class")]
    public Bone bone;

    public void C_Init(string name, float movespeed, float jumpforce) //캐릭터 초기화
    {
        Caric_Setting(name, movespeed, jumpforce);
        Caric_GetComponent();
        Caric_GetClass();
    }

    public void Caric_Setting(string name, float movespeed, float jumpforce) //캐릭터 기본 값 셋팅
    {
        caricName = name;
        moveSpeed = movespeed;
        jumpForce = jumpforce;
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

    public abstract void SetCommandState(ATTACK_STATE command);
    
}

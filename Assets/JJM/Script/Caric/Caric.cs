using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric : MonoBehaviour
{
    [Header("=====Base Caric Class=====")]
    public float moveDir; //수평 값
    public float moveSpeed;
    public float jumpForce;

    [Header("Component")]
    public Animation anim;
    public SpriteRenderer spriterenderer;
    public Rigidbody2D rigid;
    public virtual void Start()
    {
        C_Init();
    }

    public void C_Init() //캐릭터 초기화
    {
        Caric_Setting();
        Caric_GetComponent();
    }

    public void Caric_Setting()
    {
        moveDir = 0;
        moveSpeed = 10;
        jumpForce = 6;
    }

    public void Caric_GetComponent()
    {
        anim = GetComponent<Animation>();
        spriterenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;
using System;

public abstract class Caric : MonoBehaviour
{
    [Header("=====Base Caric Class=====")]
    public string caricName;
    public int caricNumber;
    public CARIC_STATE currenState = CARIC_STATE.STAND;
    public CharactorType charactorType;

    public float maxHp = V.PLAYER_MAXHP;
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;

            if (hp < 0) hp = 0;
            else if (hp > maxHp) hp = maxHp;
        }
    }
    private float hp;
    public float dmg;
    public float dir;
    public float moveSpeed;
    public float jumpForce;
    public bool isGuard;
    public bool isMoojuck = false;

    [Header("Effect")]
    public string hitEffectName;

    [Header("AttackDmg")]
    public float Weak_Attack_Dmg;
    public float Strong_Attack_Dmg;
    public float Crouch_Attack_Dmg;
    public float Jump_Attack_Dmg;
    public float Command_Weak_Dmg;
    public float Command_Strong_Dmg;

    [Header("AttackCommands")]
    public Attack attackState;
    public State commandWeakState;
    public State commandStrongState;

    [Header("Components")]
    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rigid;

    [Header("Class")]
    public Bone bone;
    public AttackBox attackBox;

    public event EventHandler onHitEvent;
    public abstract Attack SetCommandState(ATTACK_STATE command);
    public void C_Init(string name, float movespeed, float jumpforce, string hiteffectname) //캐릭터 초기화
    {
        Caric_Setting(name, movespeed, jumpforce, hiteffectname);
        Caric_GetComponent();
        Caric_GetClass();

    }

    public void Caric_Setting(string name, float movespeed, float jumpforce, string hiteffectname) //캐릭터 기본 값 셋팅
    {
        caricName = name;
        Hp = maxHp;
        moveSpeed = movespeed;
        jumpForce = jumpforce;
        hitEffectName = hiteffectname;
        isGuard = false;
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
        attackBox = GetComponentInChildren<AttackBox>();
    }

    public void AddJumpingForce()
    {
        rigid.AddForce(Vector2.one * new Vector2(dir * (moveSpeed), jumpForce), ForceMode2D.Impulse);
    }

    public void FlipSprite(float dir) //좌우 반전
    {
        FlipSprite(dir, gameObject);
    }
    public void FlipSprite(float dir, GameObject obj) //좌우 반전
    {
        obj.transform.localScale =
            new Vector3(Mathf.Abs(gameObject.transform.localScale.x) * dir, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }

    public void CreateDustMoveEffect() 
    {
        var effect = Effect.Instance.GetEffect("Dust_Walk", bone.foot.transform.position);
        FlipSprite(dir, effect);
    }

    public void OnHitFalse() 
    {
        attackBox.onHit = false;
    }

    public void OnHit() //히트 이벤트 호출
    {
        if (onHitEvent == null) return;

        onHitEvent(this, EventArgs.Empty);
    }

    public abstract void PlaySound(eCHARACTOR_SOUND_TYPE sound);
}

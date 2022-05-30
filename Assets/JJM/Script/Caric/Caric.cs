using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric : MonoBehaviour
{
    [Header("=====Base Caric Class=====")]
    public Animation anim;
    public SpriteRenderer spriterenderer;

    public virtual void Start()
    {
        C_Init();
    }

    public void C_Init() //캐릭터 초기화
    {
        anim = GetComponent<Animation>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
}

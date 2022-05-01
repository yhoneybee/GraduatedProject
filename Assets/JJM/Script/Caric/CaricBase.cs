using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CARIC_STATE //캐릭터 상태 enum
{
    IDLE,
    WALK,
    RUN,
    JUMP,
    FALL,
    ONAIR,
    HIT,
    DIE,
}

public class CaricBase : MonoBehaviour //캐릭터 베이스
{
    public CARIC_STATE caric_State;
    public float hp;
    public float mp;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    public void ChangeState(CARIC_STATE caricstate) //상태 변경
    {
        caric_State = caricstate;
    }

}

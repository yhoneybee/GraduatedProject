using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDae_Main : Caric
{
    //[Header("=====SamDae Class=====")]
    // Start is called before the first frame update
    public void Awake()
    {
        C_Init("SamDae", 5f, 6f);
    }

    void Update()
    {

    }

    public override void SetCommandState(ATTACK_STATE command)
    {
        switch (command) 
        {
            case ATTACK_STATE.ATTACK_WEAK:
                attackState = gameObject.AddComponent<Attack_Weak>();
                break;
            case ATTACK_STATE.ATTACK_STRONG:
                attackState = gameObject.AddComponent<Attack_Strong>();
                break;
            case ATTACK_STATE.ATTACK_CROUCH:
                attackState = gameObject.AddComponent<Attack_Crouch>();
                break;
            case ATTACK_STATE.ATTACK_JUMP:
                attackState = gameObject.AddComponent<Attack_Jump>();
                break;
            case ATTACK_STATE.ATTACK_COMMAND_WEAK:
                attackState = gameObject.AddComponent<Jump>();
                break;
            case ATTACK_STATE.ATTACK_COMMAND_STRONG:
                attackState = gameObject.AddComponent<Jump>();
                break;
        }
    }

}

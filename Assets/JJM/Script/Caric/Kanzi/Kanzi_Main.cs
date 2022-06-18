using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanzi_Main : Caric
{
    // Start is called before the first frame update
    void Awake()
    {
        C_Init("Kanzi", 5f, 6f);
    }

    // Update is called once per frame
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

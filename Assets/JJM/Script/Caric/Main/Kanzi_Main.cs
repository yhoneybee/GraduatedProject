using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanzi_Main : Caric
{
    // Start is called before the first frame update
    void Awake()
    {
        C_Init("Kanzi", 5f, 6f, "Hit_Kanzi");
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Attack SetCommandState(ATTACK_STATE command)
    {
        switch (command)
        {
            case ATTACK_STATE.ATTACK_WEAK:
                attackState = gameObject.AddComponent<Attack_Weak>();
                dmg = Weak_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_STRONG:
                attackState = gameObject.AddComponent<Attack_Strong>();
                dmg = Strong_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_CROUCH:
                attackState = gameObject.AddComponent<Attack_Crouch>();
                dmg = Crouch_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_JUMP:
                attackState = gameObject.AddComponent<Attack_Jump>();
                dmg = Jump_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_COMMAND_WEAK:
                attackState = gameObject.AddComponent<SamDae_Command_Weak>();
                dmg = Command_Weak_Dmg;
                break;
            case ATTACK_STATE.ATTACK_COMMAND_STRONG:
                attackState = gameObject.AddComponent<SamDae_Command_Strong>();
                dmg = Command_Strong_Dmg;
                break;
        }

        return attackState;
    }

}

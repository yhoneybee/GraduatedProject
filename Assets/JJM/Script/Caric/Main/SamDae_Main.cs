using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDae_Main : Caric
{
    //[Header("=====SamDae Class=====")]
    // Start is called before the first frame update
    public void Awake()
    {
        C_Init("SamDae", 5f, 8f, "Hit_SamDae");
    }
    private void Start()
    {
    }

    void Update()
    {

    }

    public override Attack SetCommandState(ATTACK_STATE command)
    {
        switch (command) 
        {
            case ATTACK_STATE.ATTACK_WEAK:
                attackState = gameObject.AddComponent<Attack_Weak>();
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Weak_Attack_Dmg;
                SoundManager.Instance.PlaySamdaeSound(eCHARACTOR_SOUND_TYPE.Attack);
                break;
            case ATTACK_STATE.ATTACK_STRONG:
                attackState = gameObject.AddComponent<Attack_Strong>();
                SoundManager.Instance.PlaySamdaeSound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Strong_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_CROUCH:
                attackState = gameObject.AddComponent<Attack_Crouch>();
                SoundManager.Instance.PlaySamdaeSound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Crouch_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_JUMP:
                attackState = gameObject.AddComponent<Attack_Jump>();
                SoundManager.Instance.PlaySamdaeSound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Jump_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_COMMAND_WEAK:
                attackState = gameObject.AddComponent<SamDae_Command_Weak>();
                SoundManager.Instance.PlaySamdaeSound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Command_Weak_Dmg;
                break;
            case ATTACK_STATE.ATTACK_COMMAND_STRONG:
                attackState = gameObject.AddComponent<SamDae_Command_Strong>();
                SoundManager.Instance.PlaySamdaeSound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.FLY;
                dmg = Command_Strong_Dmg;
                break;
        }

        return attackState;
    }
}

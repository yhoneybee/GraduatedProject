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

    public override void PlaySound(eCHARACTOR_SOUND_TYPE sound)
    {
        SoundManager.Instance.PlaySamdaeSound(sound);
    }

    public override Attack SetCommandState(ATTACK_STATE command)
    {
        switch (command) 
        {
            case ATTACK_STATE.ATTACK_WEAK:
                attackState = gameObject.AddComponent<Attack_Weak>();
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Weak_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_STRONG:
                attackState = gameObject.AddComponent<Attack_Strong>();
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Strong_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_CROUCH:
                attackState = gameObject.AddComponent<Attack_Crouch>();
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Crouch_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_JUMP:
                attackState = gameObject.AddComponent<Attack_Jump>();
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Jump_Attack_Dmg;
                break;
            case ATTACK_STATE.ATTACK_COMMAND_WEAK:
                attackState = gameObject.AddComponent<SamDae_Command_Weak>();
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Command_Weak_Dmg;
                break;
            case ATTACK_STATE.ATTACK_COMMAND_STRONG:
                attackState = gameObject.AddComponent<SamDae_Command_Strong>();
                PlaySound(eCHARACTOR_SOUND_TYPE.Command);
                attackBox.attackType = ATTACKTYPE.FLY;
                dmg = Command_Strong_Dmg;
                break;
        }

        return attackState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanzi_Main : Caric
{
    // Start is called before the first frame update
    void Awake()
    {
        C_Init("Kanzi", 5f, 8f, "Hit_Kanzi");
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShotSlash() 
    {
        var slash = Effect.Instance.GetEffect("KanziSlash", attackBox.transform.position).GetComponent<KanziSlash>();
        slash.playerCaric = this;
        slash.dir = (gameObject.transform.localScale.x > 0) ? Vector3.right : Vector3.left;
        slash.GetComponent<SpriteRenderer>().flipX = (gameObject.transform.localScale.x > 0);
    }

    public override void PlaySound(eCHARACTOR_SOUND_TYPE sound)
    {
        SoundManager.Instance.PlayKanziSound(sound);
    }

    public override Attack SetCommandState(ATTACK_STATE command)
    {
        switch (command)
        {
            case ATTACK_STATE.ATTACK_WEAK:
                attackState = gameObject.AddComponent<Attack_Weak>();
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Weak_Attack_Dmg;
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                break;
            case ATTACK_STATE.ATTACK_STRONG:
                attackState = gameObject.AddComponent<Attack_Strong>();
                attackBox.attackType = ATTACKTYPE.FLY;
                dmg = Strong_Attack_Dmg;
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                break;
            case ATTACK_STATE.ATTACK_CROUCH:
                attackState = gameObject.AddComponent<Attack_Crouch>();
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Crouch_Attack_Dmg;
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                break;
            case ATTACK_STATE.ATTACK_JUMP:
                attackState = gameObject.AddComponent<Attack_Jump>();
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Jump_Attack_Dmg;
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                break;
            case ATTACK_STATE.ATTACK_COMMAND_WEAK:
                attackState = gameObject.AddComponent<Kanzi_Command_Weak>();
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Command_Weak_Dmg;
                PlaySound(eCHARACTOR_SOUND_TYPE.Command);
                break;
            case ATTACK_STATE.ATTACK_COMMAND_STRONG:
                attackState = gameObject.AddComponent<Kanzi_Command_Strong>();
                attackBox.attackType = ATTACKTYPE.HIT;
                dmg = Command_Strong_Dmg;
                PlaySound(eCHARACTOR_SOUND_TYPE.Attack);
                break;
        }

        return attackState;
    }

}

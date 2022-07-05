using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyPacket;

public class JudgmentSign //판정 사인
{
    public Caric Attacker = null;
    public Caric Defender = null;
    public ATTACKTYPE AttackType = ATTACKTYPE.HIT;
    public float HitPosX = 0;
    public JudgmentSign(Caric attacker, Caric defender, ATTACKTYPE attackType, float hitPosX)
    {
        Attacker = attacker;
        Defender = defender;
        AttackType = attackType;
        HitPosX = hitPosX;
        Judgment.Instance.signQueue.Enqueue(this);
    }
}

public class Judgment : Singleton<Judgment> //판정 매니저
{
    public Queue<JudgmentSign> signQueue = new Queue<JudgmentSign>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (signQueue.Count > 0) //사인 큐가 남아있을 때
        {
            JudgmentSign sign = signQueue.Dequeue();
            Caric attacker = sign.Attacker; //공격자
            Caric defender = sign.Defender; //방어자


            if (defender.isGuard) //가드 상태
            {
                Effect.Instance.GetEffect("Guard", new Vector2(sign.HitPosX, defender.bone.body.transform.position.y));
                defender.PlaySound(eCHARACTOR_SOUND_TYPE.Defence);
            }
            else //피격 상태
            {
                defender.Hp -= attacker.dmg; //데미지 만큼 Hp 감소

                Effect.Instance.GetEffect(attacker.hitEffectName, new Vector2(sign.HitPosX, defender.bone.body.transform.position.y));

                UI.Instance.HpSliderValueChange(defender.Hp, defender.caricNumber);

                CaricAI defenderAi = defender.GetComponent<CaricAI>();

                attacker.PlaySound(eCHARACTOR_SOUND_TYPE.AttackSfx);

                if (defender.Hp > 0) //피격
                {

                    switch (sign.AttackType)
                    {
                        case ATTACKTYPE.HIT:

                            switch (defender.currenState) //현재 상대 플레이어의 상태
                            {
                                case CARIC_STATE.STAND:
                                    defenderAi.ChangeState(defender.gameObject.AddComponent<Hit>());
                                    break;
                                case CARIC_STATE.CROUCH:
                                    defenderAi.ChangeState(defender.gameObject.AddComponent<Crouch_Hit>());
                                    break;
                                case CARIC_STATE.JUMP:
                                    defenderAi.ChangeState(defender.gameObject.AddComponent<Fly>());
                                    break;
                            }

                            break;
                        case ATTACKTYPE.FLY:
                            defenderAi.ChangeState(defender.gameObject.AddComponent<Fly>());
                            break;
                        case ATTACKTYPE.STUN:
                            defenderAi.ChangeState(defender.gameObject.AddComponent<Hit>());
                            break;
                    }

                    defender.PlaySound(eCHARACTOR_SOUND_TYPE.Hit);
                }
                else //사망
                {
                    defenderAi.ChangeState(defender.gameObject.AddComponent<Die>());

                    defender.PlaySound(eCHARACTOR_SOUND_TYPE.Die);

                    UI.Instance.OnGameEnd();
                }
            }

            defender.OnHit();
        }
    }


}

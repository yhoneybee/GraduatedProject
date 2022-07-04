using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class JudgmentSign //���� ����
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

public class Judgment : Singleton<Judgment> //���� �Ŵ���
{
    public Queue<JudgmentSign> signQueue = new Queue<JudgmentSign>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (signQueue.Count > 0) //���� ť�� �������� ��
        {
            JudgmentSign sign = signQueue.Dequeue();
            Caric attacker = sign.Attacker; //������
            Caric defender = sign.Defender; //�����

            if (defender.isGuard) //���� ����
            {
                Effect.Instance.GetEffect("Guard", new Vector2(sign.HitPosX, defender.bone.body.transform.position.y));
            }
            else //�ǰ� ����
            {
                defender.Hp -= attacker.dmg; //������ ��ŭ Hp ����

                Effect.Instance.GetEffect(attacker.hitEffectName, new Vector2(sign.HitPosX, defender.bone.body.transform.position.y));

                UI.Instance.HpSliderValueChange(defender.Hp, defender.caricNumber);

                CaricAI defenderAi = defender.GetComponent<CaricAI>();

                if (defender.Hp > 0) //�ǰ�
                {
                    switch (sign.AttackType)
                    {
                        case ATTACKTYPE.HIT:

                            switch (defender.currenState) //���� ��� �÷��̾��� ����
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
                }
                else //���
                {
                    defenderAi.ChangeState(defender.gameObject.AddComponent<Die>());

                    UI.Instance.OnGameEnd();
                }
            }

        }
    }


}

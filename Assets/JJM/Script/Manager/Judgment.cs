using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class JudgmentSign //���� ����
{
    public Caric Attacker = null;
    public Caric Defender = null;
    public ATTACKTYPE AttackType = ATTACKTYPE.HIT;

    public JudgmentSign(Caric attacker, Caric defender, ATTACKTYPE attackType)
    {
        Attacker = attacker;
        Defender = defender;
        AttackType = attackType;
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

            defender.Hp -= attacker.dmg; //������ ��ŭ Hp ����
            UI.Instance.HpSliderValueChange(defender.Hp, defender.caricNumber);

            CaricAI defenderAi = defender.GetComponent<CaricAI>();

            if (defender.Hp > 0) //�ǰ�
            {
                switch (sign.AttackType)
                {
                    case ATTACKTYPE.HIT:

                        string denfenderStateName = defender.gameObject.GetComponent<State>().GetType().Name;

                        if (denfenderStateName == "Crouch" || denfenderStateName == "Crouch_Attack")
                            defenderAi.ChangeState(defender.gameObject.AddComponent<Crouch_Hit>());
                        else
                            defenderAi.ChangeState(defender.gameObject.AddComponent<Hit>());
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
            }

        }
    }


}

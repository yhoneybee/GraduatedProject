using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentSign //판정 사인
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
        if(signQueue.Count > 0) //사인 큐가 남아있을 때
        {
            JudgmentSign sign = signQueue.Dequeue();
            Caric attacker = sign.Attacker;
            Caric defender = sign.Defender;

            defender.Hp -= attacker.dmg;
            UI.Instance.HpSliderValueChange(attacker.dmg, defender.caricNumber);

            CaricAI defenderAi = defender.GetComponent<CaricAI>();

            if(defender.Hp > 0) //피격
            {
                switch (sign.AttackType) 
                {
                    case ATTACKTYPE.HIT:
                        if (defenderAi.cs == CARIC_STATE.CROUCH)
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
            else //사망
            {
                defenderAi.ChangeState(defender.gameObject.AddComponent<Die>());
            }

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ATTACKTYPE 
{
    HIT,
    STUN,
    FLY,
}

public class AttackBox : MonoBehaviour
{
    public ATTACKTYPE attackType;
    public Caric playerCaric;
    public bool onHit;

    void Start()
    {
        if (!playerCaric) playerCaric = GetComponentInParent<Caric>();
        onHit = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other != null && !onHit)
        {
            if (other.gameObject.tag == "Caric") 
            {
                Caric enemyCaric = other.GetComponentInParent<Caric>();
                Attack nowAttack = GetComponentInParent<Attack>();

                if (enemyCaric == playerCaric || enemyCaric.Hp == 0 || enemyCaric.isMoojuck) return;
                if (nowAttack == null) return;

                nowAttack.OnAttack(enemyCaric);

                float hitPointX = other.transform.position.x + Random.Range(-0.5f, 0.5f); 

                onHit = true;
                Debug.Log("OnHit : " + onHit);

                new JudgmentSign(playerCaric, enemyCaric, attackType, hitPointX);

                Debug.Log("NowState : " + nowAttack.GetType().Name);
            }
        }
    }
}

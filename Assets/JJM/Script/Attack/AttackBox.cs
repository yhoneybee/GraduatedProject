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
    void Start()
    {
        playerCaric = GetComponentInParent<Caric>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.gameObject.tag == "Caric") 
            {
                Caric enemyCaric = other.GetComponentInParent<Caric>();
                Attack nowAttack = GetComponentInParent<Attack>();

                if (enemyCaric == playerCaric) return;
                if (nowAttack == null) return;

                nowAttack.OnAttack(enemyCaric);
                new JudgmentSign(playerCaric, enemyCaric, attackType);

                Debug.Log("NowState : " + nowAttack.GetType().Name);
            }
        }
    }
}

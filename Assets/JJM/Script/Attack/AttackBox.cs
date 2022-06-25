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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Attack nowAttack = transform.parent.GetComponent<Attack>();
                
                if (nowAttack != null) 
                {
                    Caric playerCaric = this.transform.parent.GetComponent<Caric>();
                    Caric enemyCaric = other.GetComponent<Caric>();

                    nowAttack.OnAttack(enemyCaric);
                    new JudgmentSign(playerCaric, enemyCaric, attackType);

                    Debug.Log("NowState : " + nowAttack.GetType().Name);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanziSlash : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Caric playerCaric;
    public Vector3 dir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.gameObject.tag == "Caric")
            {
                Caric enemyCaric = other.GetComponentInParent<Caric>();

                if (enemyCaric == playerCaric || enemyCaric.Hp == 0) return;

                float hitPointX = other.transform.position.x + Random.Range(-0.5f, 0.5f);

                new JudgmentSign(playerCaric, enemyCaric, ATTACKTYPE.HIT, hitPointX);

                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "Slash") 
            {
                Destroy(gameObject);
            }
        }
    }
}

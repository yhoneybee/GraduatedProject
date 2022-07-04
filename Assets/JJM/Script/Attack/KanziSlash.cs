using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanziSlash : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Caric playerCaric;
    public Vector3 dir;
    ContactPoint2D[] hitpoint = new ContactPoint2D[2];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.gameObject.tag == "Caric")
            {
                Caric enemyCaric = other.GetComponentInParent<Caric>();

                if (enemyCaric == playerCaric || enemyCaric.Hp == 0) return;

                other.GetContacts(hitpoint);

                new JudgmentSign(playerCaric, enemyCaric, ATTACKTYPE.HIT, hitpoint[0].point.x);

                Destroy(gameObject);
            }
        }
    }
}

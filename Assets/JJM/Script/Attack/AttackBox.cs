using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    Caric caric;
    // Start is called before the first frame update
    private void OnEnable()
    {
        float dirX = (caric.sprite.flipX) ? transform.position.x * -1 : transform.position.x * 1;
        gameObject.transform.position = new Vector3(dirX, transform.position.y, transform.position.z);
    }

    void Start()
    {
        caric = transform.parent.GetComponent<Caric>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

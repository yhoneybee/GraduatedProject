using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    Caric owner;

    void Start()
    {
        owner = transform.parent.GetComponent<Caric>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

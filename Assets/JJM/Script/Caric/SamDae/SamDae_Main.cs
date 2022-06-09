using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDae_Main : Caric
{
    //[Header("=====SamDae Class=====")]
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        moveDir = V.GetAxisRaw("Horizontal"); 
    }

    
}

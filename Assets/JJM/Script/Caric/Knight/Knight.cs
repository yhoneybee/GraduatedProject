using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Caric
{
    [Header("=====Night Class=====")]
    public string nowKey; //현재 입력한 키   

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        nowKey = Input.inputString;
    }
}

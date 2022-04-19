using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MakeMatchingUserInfo
{
    public MakeMatchingUserInfo(bool isReady)
    {
        this.isReady = isReady;
    }
    public bool isReady;
}
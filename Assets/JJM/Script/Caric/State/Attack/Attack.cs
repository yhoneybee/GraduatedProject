using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public abstract class Attack : State
{
    public abstract void OnAttack(Caric other);

    bool IsPowerCrash = false;
}

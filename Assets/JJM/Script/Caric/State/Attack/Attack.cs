using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : State
{
    public abstract void OnAttack(Caric other);

}

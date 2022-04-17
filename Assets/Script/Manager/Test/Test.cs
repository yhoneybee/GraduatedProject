using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        if (CURDFactory.GetCURDable(out var curd))
        {
            curd.Sign("Justbee", "Kkulbeol", "123", "123");
        }
    }
}

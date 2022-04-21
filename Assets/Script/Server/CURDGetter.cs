using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CURDGetter
{
    public static bool GetCURDable(eCURD_TYPE curdType, out ICURDable curd)
    {
        curd = curdType switch
        {
            eCURD_TYPE.Firebase => new SFirebase(),
            _ => null,
        };
        return curd.Initialize();
    }

    public static bool GetCURDable(out ICURDable curd) => GetCURDable(K.selectCURDType, out curd);
}

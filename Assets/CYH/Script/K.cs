using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SERVER;
public enum DB
{
    MySQL,
    End,
}

public static class K
{
    static SQL[] db = new SQL[((int)DB.End)];

    public static SQL GetDB(DB dbType)
    {
        if (db[((int)dbType)] == null)
        {
            db[((int)dbType)] = dbType switch
            {
                DB.MySQL => new MySQL(),
                _ => null,
            };
            db[((int)dbType)].Initilize();
        }
        return db[((int)dbType)];
    }
}

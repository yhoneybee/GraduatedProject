using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using SERVER;
using System.Text;

public enum DB
{
    MySQL,
    End,
}

public static class K
{
    static SQL[] db = new SQL[((int)DB.End)];

    static DB selectDb = DB.MySQL;

    public static SQL GetDB() => GetDB(selectDb);

    public static string loginedId;

    static SQL GetDB(DB dbType)
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

    public static string SHA256(string data)
    {
        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
        StringBuilder stringBuilder = new StringBuilder();
        foreach (byte b in hash)
        {
            stringBuilder.AppendFormat("{0:x2}", b);
        }
        return stringBuilder.ToString();
    }
}

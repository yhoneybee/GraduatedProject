using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class K
{
    public static string SHA256(string data)
    {
        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
        StringBuilder sb = new StringBuilder();
        foreach (var b in hash)
            sb.Append($"{b:x2}");
        return sb.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class Json
{
    public static bool HasFile(string name) => File.Exists(Path.Combine(Application.persistentDataPath, name));

    public static void Write<T>(T save, string name, bool force = true)
    {
        if (!force && HasFile(name)) return;

        string json = JsonUtility.ToJson(save, true);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, name), json);
    }

    public static T Read<T>(string name)
    {
        string json = File.ReadAllText(Path.Combine(Application.persistentDataPath, name));
        return JsonUtility.FromJson<T>(json);
    }
}

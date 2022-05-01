using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class V : MonoBehaviour
{
    public static float GetAxis(string axisname)
    {
        return Input.GetAxis(axisname);
    }

    public static bool GetKeyDown(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }

    public static bool GetKeyUp(KeyCode key)
    {
        return Input.GetKeyUp(key);
    }

    public static bool GetKey(KeyCode key)
    {
        return Input.GetKey(key);
    }
}

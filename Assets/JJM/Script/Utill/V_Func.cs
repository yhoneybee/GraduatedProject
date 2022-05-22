using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class V : MonoBehaviour //공용 함수 클래스
{
    public static float GetAxis(string key)
    {
        return Input.GetAxis(key);
    }
    public static float GetAxisRaw(string key)
    {
        return Input.GetAxisRaw(key);
    }
    public static bool GetKey(KeyCode key)
    {
        return Input.GetKey(key);
    }
    public static bool GetKeyDown(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }
    public static bool GetKeyUp(KeyCode key)
    {
        return Input.GetKeyUp(key);
    }
}

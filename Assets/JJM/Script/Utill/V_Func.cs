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

    public static bool MoveKeyUp()
    {
        if(V.GetKeyUp(KeyCode.A) || V.GetKeyUp(KeyCode.D)) return true;

        return false;
    }

    public static List<T> Find_Child_Component_List<T>(GameObject rootObj) where T : Component //자식 오브젝트 리스트<T> 리턴
    {
        if (rootObj == null) return null;

        var allChilds = rootObj.GetComponentsInChildren<T>();

        List<T> list = new List<T>();

        foreach (var child in allChilds)
        {
            if (child.name == rootObj.name) continue;

            list.Add(child);   
        }

        return list;
    }

    public static GameObject Find_Child_Name(string name, GameObject rootObj) //자식 이름으로 오브젝트 찾기
    {
        if (rootObj == null) return null;

        var allChilds = rootObj.GetComponentsInChildren<Transform>();

        foreach(var child in allChilds) 
        {
            if (child.name == rootObj.name) continue;
            
            if(child.name == name) 
            {
                return child.gameObject;
            }
        }

        return null;
    }
}

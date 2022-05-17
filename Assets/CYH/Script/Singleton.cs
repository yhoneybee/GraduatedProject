using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : class
{
    static T instance;
    public T Instance
    {
        get
        {
            if (instance == null)
                instance = GetComponent<T>();

            return instance;
        }
    }

    void OnDestroy()
    {
        instance = null;
    }
}
